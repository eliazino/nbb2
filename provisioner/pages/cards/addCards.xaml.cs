using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HealthTouchLib;
using provisioner.codelibrary.database;
using provisioner.codelibrary.utils;

namespace provisioner.pages.cards {
    /// <summary>
    /// Interaction logic for addCards.xaml
    /// </summary>
    public partial class addCards : Page {
        public static System.Timers.Timer aTimer;
        private delegate void NoArgDelegate();
        private string lastSyncedSerial = string.Empty;
        private bool isWrittenID = false;
        private HealthTouchCoreLib core;
        private bool ReadNow = true;
        public addCards() {
            InitializeComponent();
        }
        public void clearField() {
            staffID.Clear();
            cardSerial.Clear();
        }
        private void backGroundThread() {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(listener);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }
        private void listener(object source, ElapsedEventArgs e) {
            counterOperator();
            if (ReadNow) {
                try {
                    this.Dispatcher.Invoke(() => {
                        try {
                            core = new HealthTouchLib.HealthTouchCoreLib();
                            if (true) {//lastSyncedSerial != core.ReadCardId(0)) {
                                //lastSyncedSerial = core.ReadCardId(0);
                                cardSerial.Text = core.ReadCardId(0);
                                lastSyncedSerial = core.ReadCardId(0).Replace("-", "");
                                cardSerial.Text = core.ReadCardId(0).Replace("-", "");
                            }
                        } catch (Exception et) {
                            Console.WriteLine(et.ToString());
                        }
                    });
                } catch (Exception) {

                }
            }
        }
        private void counterOperator() {
            try {
                string syncedSql = "select * from cards where synced = 1";
                string totalSql = "select * from cards";
                DbEntity db = new DbEntity();
                int totalCount = db.colExists(totalSql);
                int syncedCount = db.colExists(syncedSql);
                this.Dispatcher.Invoke(() => {
                    total.Content = totalCount.ToString();
                    synced.Content = syncedCount.ToString();
                });
            } catch (Exception e) {

            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            var delegateOne = Task.Factory.StartNew(() => backGroundThread());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.backGroundThread);
            fetcher.BeginInvoke(null, null);*/
        }

        private void saveCard(object sender, RoutedEventArgs e) {
            saveButton();
        }

        private void saveButton() {
            string staff = staffID.Text;
            string card = cardSerial.Text;
            ReadNow = false;
            if (!string.IsNullOrEmpty(staff) && !string.IsNullOrEmpty(card)) {
                Int32 lastseen = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string sql = "insert into cards (cardSerial, staffI, issuerID, dateCreated) values ('" + card + "', '" + staff +
                             "', 'HonWell', '" + lastseen.ToString() + "')";
                DbEntity db = new DbEntity();
                if (db.execQuery(sql)) {
                    clearField();
                } else {
                    sql = "insert into duplicateCards (cardSerial, staffI, issuerID, dateCreated) values ('" + card + "', '" +
                          staff + "', 'HonWell', '" + lastseen.ToString() + "')";
                    db.execQuery(sql);
                    MessageBox.Show(
                        "Something Went wrong and the card could not be added. \n The card or staffID might have been previously added",
                        "St.-1 Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                try {
                    HealthTouchCoreLib ctwo = new HealthTouchCoreLib();
                    ctwo.EncodeSecure(0);
                    bool cv = ctwo.ProvisionSecure("a:" + staff + ",p:0", 0);
                    if (cv) {
                    } else {
                        MessageBox.Show(
                            "You may not have placed the card well for writting. Replace the card and try saving the StaffID again. ",
                            "St.-1 Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } catch (Exception ex) {
                }
            } else {
                MessageBox.Show("Staff Id or card Serial Empty");
            }
            ReadNow = true;
        }
        private void goToCards(object sender, RoutedEventArgs e) {
            MainWindow min = new MainWindow();
            min.ContentPage.Content = null;
            NavigationService.Navigate(new Uri("pages/cards/browseCards.xaml", UriKind.Relative));
        }

        private void syncCards(object sender, RoutedEventArgs e) {
            cardSyncer.IsEnabled = false;
            syncIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Spinner;
            syncIcon.Spin = true;
            var delegateTwo = Task.Factory.StartNew(() => trySyncCard());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.trySyncCard);
            fetcher.BeginInvoke(null, null);*/
        }
        private void trySyncCard() {
            try {
                string sql = "select * from cards where synced = 0 limit 200";
                DbEntity db = new DbEntity();
                strFormater formated = db.writeCards(sql);
                string datum = formated.cardObjs;
                dataTable profile = db.fetchAdminprofile("select*from admin order by id desc limit 1");
                serviceHelper.syncCard(profile.adminUname, profile.adminKey, datum);
                this.Dispatcher.Invoke(() => {
                    cardSyncer.IsEnabled = true;
                    syncIcon.Icon = FontAwesome.WPF.FontAwesomeIcon.Cloud;
                    syncIcon.Spin = false;
                });
            } catch (Exception) {
            }
        }

        private void staffID_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if(e.Key == Key.Return) {
                saveButton();
            }

        }
    }
}
