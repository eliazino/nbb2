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
using provisioner.codelibrary.utils;
using provisioner.codelibrary.database;
using System.ComponentModel;
using provisioner.codelibrary.database;
namespace provisioner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            serviceHelper services = new serviceHelper();
            if (services.verifyUser()) {
                //DbEntity db = new DbEntity();
                //db.doMagic();
                ContentPage.NavigationService.Navigate(new Uri("pages/cards/addCards.xaml", UriKind.Relative));
            } else {
                ContentPage.NavigationService.Navigate(new Uri("pages/login.xaml", UriKind.Relative));
            }
        }        
        private void Home_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            serviceHelper services = new serviceHelper();
            if (services.verifyUser()) {
                ContentPage.NavigationService.Navigate(new Uri("pages/cards/addCards.xaml", UriKind.Relative));
            } else {
                provisioner.pages.cards.addCards.aTimer.Stop();
                ContentPage.NavigationService.Navigate(new Uri("pages/login.xaml", UriKind.Relative));
            }
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            hamMenu.IsOpen = true;
        }


        private void cards_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            serviceHelper services = new serviceHelper();
            if (services.verifyUser()) {
                ContentPage.NavigationService.Navigate(new Uri("pages/cards/addCards.xaml", UriKind.Relative));
            } else {
                ContentPage.NavigationService.Navigate(new Uri("pages/login.xaml", UriKind.Relative));
            }
        }
        private void staffs_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            serviceHelper services = new serviceHelper();
            if (services.verifyUser()) {
                provisioner.pages.cards.addCards.aTimer.Stop();
                ContentPage.NavigationService.Navigate(new Uri("pages/staffs/ImportStaff.xaml", UriKind.Relative));
            } else {
                ContentPage.NavigationService.Navigate(new Uri("pages/login.xaml", UriKind.Relative));
            }
        }

        private void logOut_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            string sql = "delete from admin where id > 0";
            DbEntity db = new DbEntity();
            db.execQuery(sql);
            ContentPage.NavigationService.Navigate(new Uri("pages/login.xaml", UriKind.Relative));
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
