using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using provisioner.codelibrary.database;

namespace provisioner.pages.cards {
    /// <summary>
    /// Interaction logic for browseCards.xaml
    /// </summary>
    public partial class browseCards : Page {
        private delegate void NoArgDelegate();
        public browseCards() {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            spinner2.Visibility = Visibility.Visible;
            NoArgDelegate fetcher = new NoArgDelegate(
                   this.loadLog);
            fetcher.BeginInvoke(null, null);
        }
        private void loadLog() {
            try {
                int syn = 0;
                string sql = "select * from cards";
                dataTable dataTabl = new DbEntity().getCards(sql);
                if (dataTabl.cardSerial.Length > 0) {
                    List<Card> uso = new List<Card>();
                    int start = 0;
                    while (start < dataTabl.cardSerial.Length) {
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(Double.Parse(dataTabl.date[start])).ToLocalTime();
                        string date = dtDateTime.ToString();
                        uso.Add(new Card() { ID = start + 1, serial = dataTabl.cardSerial[start], staffID = dataTabl.staff[start], cardSynced = (dataTabl.synced[start]== "1")? "Yes" : "No", dateAdded = date});
                        if(dataTabl.synced[start] == "1") {
                            syn++;
                        }
                        start++;
                    }
                    this.Dispatcher.Invoke(() => {
                        transTab.ItemsSource = uso;
                        spinner2.Visibility = Visibility.Collapsed;
                        synced.Content = syn.ToString();
                        total.Content = start.ToString();
                    });                    
                    }

                syn = 0;
                sql = "select * from duplicateCards";
                dataTabl = new DbEntity().getCards(sql);
                if (dataTabl.cardSerial.Length > 0) {
                    List<Card> usom = new List<Card>();
                    int start = 0;
                    while (start < dataTabl.cardSerial.Length) {
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(Double.Parse(dataTabl.date[start])).ToLocalTime();
                        string date = dtDateTime.ToString();
                        usom.Add(new Card() { ID = start + 1, serial = dataTabl.cardSerial[start], staffID = dataTabl.staff[start], cardSynced = (dataTabl.synced[start] == "1") ? "Yes" : "No", dateAdded = date });
                        if (dataTabl.synced[start] == "1") {
                            syn++;
                        }
                        start++;
                    }
                    this.Dispatcher.Invoke(() => {
                        transTab2.ItemsSource = usom;
                        spinner3.Visibility = Visibility.Collapsed;
                    });
                }
                } catch (Exception) {
            }
        }
        public class Card {
            public int ID { get; set; }
            public string serial { get; set; }
            public string staffID { get; set; }
            public string cardSynced { get; set; }
            public string dateAdded { get; set; }
        }
    }
}
