using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using provisioner.codelibrary.database;
using provisioner.codelibrary.utils;

namespace provisioner.pages.staffs {
    /// <summary>
    /// Interaction logic for ImportStaff.xaml
    /// </summary>
    /// 
    public partial class ImportStaff : Page {
        public static System.Timers.Timer aTimer;
        private string fileName;
        private string usert;
        private delegate void NoArgDelegate();
        public ImportStaff() {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            spinner2.Visibility = Visibility.Visible;
            var delegateOne = Task.Factory.StartNew(() => backGroundThread());
            var delegateTwo = Task.Factory.StartNew(() => loadLog());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                   this.loadLog);
            fetcher.BeginInvoke(null, null);*/
        }

        private void backGroundThread() {
            aTimer = new System.Timers.Timer(20000);
            aTimer.Elapsed += new ElapsedEventHandler(updateCount);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }
        private void uploader(object sender, RoutedEventArgs e) {
            ComboBoxItem typeItem = (ComboBoxItem)staffType.SelectedItem;
            try {
                string selString = typeItem.Content.ToString();
                string selID = typeItem.Tag.ToString();
                double tmp;
                if (!double.TryParse(selID, out tmp)) {
                    MessageBox.Show("Select a usertype to continue", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                usert = selID;
            } catch(Exception) {
                MessageBox.Show("Select a usertype to continue", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true) {
                uico.Content = "Working on it";
                ico.Icon = FontAwesome.WPF.FontAwesomeIcon.Spinner;
                ico.Spin = true;
                fileName = dialog.FileName;
                var contin = MessageBox.Show("Are you sure you want to import the staffs to the selected Staff Type?", "Notice", MessageBoxButton.YesNo, MessageBoxImage.Question);             
                if(contin == MessageBoxResult.No) {
                    uico.Content = "Upload .CSV File Only";
                    ico.Icon = FontAwesome.WPF.FontAwesomeIcon.Upload;
                    ico.Spin = false;
                    return;
                }
                var delegateThree = Task.Factory.StartNew(() => importSurrogate());
                /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.importSurrogate);
                fetcher.BeginInvoke(null, null);*/
            }
        }
        private void importSurrogate() {
            csvReader reader = new csvReader();
            try {
                reader.getFile(fileName, usert);
            } catch (Exception) {
                this.Dispatcher.Invoke(() => {
                    MessageBox.Show("The file might be in use by another software so thus could not be accessed. \nFurther more the file imported might be invalid. kindly check and try again", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
            this.Dispatcher.Invoke(() => {
                uico.Content = "Upload .CSV File Only";
                ico.Icon = FontAwesome.WPF.FontAwesomeIcon.Upload;
                ico.Spin = false;
                DbEntity db = new DbEntity();
                string sq = "select * from staffs";
                string sq2 = "select * from staffs where synced = 1";
                total.Content = db.colExists(sq).ToString();
                synced.Content = db.colExists(sq2).ToString();
                spinner2.Visibility = Visibility.Visible;
                spinner3.Visibility = Visibility.Visible;
                var delegateSeven = Task.Factory.StartNew(() => loadLog());
                //updateCount();
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            syncStaffType.IsEnabled = false;
            syncIcon.Spin = true;
            var delegateThree = Task.Factory.StartNew(() => completeSync());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.completeSync);
            fetcher.BeginInvoke(null, null);*/
        }
        public void completeSync() {
            DbEntity db = new DbEntity();
            dataTable profile = db.fetchAdminprofile("select*from admin order by id desc limit 1");
            serviceHelper.trySyncUserTypes(profile.adminUname, profile.adminKey);
            this.Dispatcher.Invoke(() => {
                syncStaffType.IsEnabled = true;
                syncIcon.Spin = false;
                populateBox();
            });

        }
        public void populateBox() {
            try {
                string sql = "select * from userTypes";
                DbEntity db = new DbEntity();
                dataTable dataTable = db.fetchUserTypes(sql);
                this.Dispatcher.Invoke(() => {
                    staffType.Items.Clear();
                    if (dataTable.userTypeString.Length > 0) {
                        for (int i = 0; i < dataTable.userTypeString.Length; i++) {
                            ComboBoxItem item = new ComboBoxItem();
                            item.Content = "Upload to: " + dataTable.userTypeString[i];
                            item.Tag = dataTable.userTypeID[i];
                            staffType.Items.Add(item);
                        }
                        staffType.SelectedIndex = 0;
                    }
                });
            } catch (Exception ex) {

            }
        }

        private void syncer(object sender, RoutedEventArgs e) {
            syncStaffs.IsEnabled = false;
            syncIco.Icon = FontAwesome.WPF.FontAwesomeIcon.Spinner;
            syncIco.Spin = true;
            var delegateThree = Task.Factory.StartNew(() => trySyncer());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.trySyncer);
            fetcher.BeginInvoke(null, null);*/
        }
        private void trySyncer() {
            try {
                string sql = "select fullname, staffs.staffID as staffID, cards.cardSerial as cardSerial, staffType, location, department, designation from staffs left join cards on cards.staffI = staffs.staffID where staffs.synced = 0 limit 100";
                DbEntity db = new DbEntity();
                strFormater formated = db.writeStaffs(sql);
                string datum = formated.staffObjs;
                dataTable profile = db.fetchAdminprofile("select*from admin order by id desc limit 1");
                serviceHelper.syncStaffs(profile.adminUname, profile.adminKey, datum);
                this.Dispatcher.Invoke(() => {
                    syncStaffs.IsEnabled = true;
                    syncIco.Icon = FontAwesome.WPF.FontAwesomeIcon.Cloud;
                    syncIco.Spin = false;
                });
            } catch (Exception) {
            }
            //updateCount();
            var delegateTwo = Task.Factory.StartNew(() => loadLog());
        }
        private void loadLog() {
            try {
                int syn = 0;
                string sql = "select fullname, tmp.staffID as staffID, tmp.synced as synced, tmp.cardSerial as cardSerial, usertypes.name as staffType, location, department, designation from (select fullname, staffs.staffID as staffID, cards.cardSerial as cardSerial, staffs.synced as synced, staffType, location, department, designation from staffs left join cards on cards.staffI = staffs.staffID) as tmp left join usertypes on usertypes.userTypeID = tmp.staffType";
                dataTable dataTabl = new DbEntity().getStaffs(sql);
                if (dataTabl.fullname.Length > 0) {
                    List<staffs> uso = new List<staffs>();
                    int start = 0;
                    while (start < dataTabl.cardSerial.Length) {
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        //dtDateTime = dtDateTime.AddSeconds(Double.Parse(dataTabl.date[start])).ToLocalTime();
                        //string date = dtDateTime.ToString();
                        uso.Add(new staffs() { ID = start + 1, fullname = dataTabl.fullname[start], staffID = dataTabl.staffID[start], staffSynced = (dataTabl.synced[start] == "1") ? "Yes" : "No", designation = dataTabl.designation[start], staffType = dataTabl.stafftype[start], location = dataTabl.location[start], cardSerial = dataTabl.cardSerial[start]  });
                        if (dataTabl.synced[start] == "1") {
                            syn++;
                        }                        
                        start++;
                    }
                    this.Dispatcher.Invoke(() => {
                        try {
                            transTab.ItemsSource = null;
                            transTab.ItemsSource = uso;
                            transTab.Items.Refresh();
                            spinner2.Visibility = Visibility.Collapsed;
                            synced.Content = syn.ToString();
                            total.Content = start.ToString();
                        } catch(Exception e) {

                        }
                    });
                    sql = "select fullname, tmp.staffID as staffID, tmp.synced as synced, tmp.cardSerial as cardSerial, usertypes.name as staffType, location, department, designation from (select fullname, duplicateStaffs.staffID as staffID, cards.cardSerial as cardSerial, duplicateStaffs.synced as synced, staffType, location, department, designation from duplicateStaffs left join cards on cards.staffI = duplicateStaffs.staffID) as tmp left join usertypes on usertypes.userTypeID = tmp.staffType";
                    dataTabl = new DbEntity().getStaffs(sql);
                    if (dataTabl.fullname.Length > 0) {
                        List<staffs> usow = new List<staffs>();
                        start = 0;
                        syn = 0;
                        while (start < dataTabl.cardSerial.Length) {
                            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                            //dtDateTime = dtDateTime.AddSeconds(Double.Parse(dataTabl.date[start])).ToLocalTime();
                            //string date = dtDateTime.ToString();
                            usow.Add(new staffs() { ID = start + 1, fullname = dataTabl.fullname[start], staffID = dataTabl.staffID[start], staffSynced = (dataTabl.synced[start] == "1") ? "Yes" : "No", designation = dataTabl.designation[start], staffType = dataTabl.stafftype[start], location = dataTabl.location[start], cardSerial = dataTabl.location[start] });
                            if (dataTabl.synced[start] == "1") {
                                syn++;
                            }
                            start++;
                        }
                        this.Dispatcher.Invoke(() => {
                            transTab2.ItemsSource = null;
                            transTab2.ItemsSource = usow;
                            transTab.Items.Refresh();
                            spinner3.Visibility = Visibility.Collapsed;
                            synced.Content = syn.ToString();
                            total.Content = start.ToString();
                        });
                    }
                    }
            } catch (Exception){
            }
            this.Dispatcher.Invoke(() => {
                spinner3.Visibility = Visibility.Collapsed;
                spinner2.Visibility = Visibility.Collapsed;
                populateBox();
                //updateCount();
            });
        }
        private void updateCount(object source, ElapsedEventArgs e) {
            DbEntity db = new DbEntity();
            string sq = "select * from staffs";
            string sq2 = "select * from staffs where synced = 1";            
            this.Dispatcher.Invoke(() => {
                total.Content = db.colExists(sq).ToString();
                synced.Content = db.colExists(sq2).ToString();
            });
        }
        public class staffs {
            public int ID { get; set; }
            public string fullname { get; set; }
            public string staffID { get; set; }
            public string cardSerial { get; set; }
            public string staffSynced { get; set; }
            public string designation { get; set; }
            public string staffType { get; set; }
            public string location { get; set; }
        }

        private void purgeConflict(object sender, RoutedEventArgs e) {
            string sql = "delete from duplicateStaffs where id > 0";
            DbEntity db = new DbEntity();
            db.execQuery(sql);
            var delegateTwo = Task.Factory.StartNew(() => loadLog());
            /*NoArgDelegate fetcher = new NoArgDelegate(
                    this.loadLog);
            fetcher.BeginInvoke(null, null);*/
        }
    }
}
