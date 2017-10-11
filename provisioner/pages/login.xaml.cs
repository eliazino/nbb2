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

namespace provisioner.pages {
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page {
        private string user;
        private string passw;
        public static string mIMEI;
        public login() {
            InitializeComponent();
        }

        private delegate void NoArgDelegate();
        private void LoginWindow_OnLoaded(object sender, RoutedEventArgs e) {

        }

        private void BtnLoginIn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

        }

        private void BtnLoginIn_Click(object sender, RoutedEventArgs e) {
            string uname = username.Text;
            string pass = password.Password;
            if (uname.Length < 1 || pass.Length < 1) {
                statusMessage.Visibility = Visibility.Visible;
                warningLab.Content = "All inputs are required";
            } else {
                statusMessage.Visibility = Visibility.Collapsed;
                loaderIm.Visibility = Visibility.Visible;
                BtnLogin.IsEnabled = false;
                this.user = uname;
                this.passw = pass;
                //asynchronously check internet and do other stuff.
                NoArgDelegate fetcher = new NoArgDelegate(
                    this.completeCheck);
                fetcher.BeginInvoke(null, null);
            }
        }
        public void completeCheck() {
            //LautechAgentApp.Domain.Utils util = new LautechAgentApp.Domain.Utils();
            try {
                if (true) {
                    if (serviceHelper.Login(this.user, this.passw)) {
                        this.Dispatcher.Invoke(() => {
                            MainWindow page = new MainWindow();
                            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                            //page.externalSurrogate();
                            //Application.Current.Startup = Application.Current.StartupUri();// = ShutdownMode.;
                            //page.Show();
                            //Application.Current.Shutdown();
                            //this.h
                            //page.ContentPage.NavigationService.Navigate(new Uri("pages/cards/addCards.xaml", UriKind.Relative));
                        });

                    } else {
                        this.Dispatcher.Invoke(() => {
                            statusMessage.Visibility = Visibility.Visible;
                            warningLab.Content = " Access Denied. Invalid Credentials";
                            loaderIm.Visibility = Visibility.Collapsed;
                        });
                    }
                } else {

                }
                this.Dispatcher.Invoke(() => {
                    BtnLogin.IsEnabled = true;
                });
            } catch (Exception) {

            }
        }

        private void revalidateProfile() {
            /*LautechAgentApp.Domain.Utils util = new LautechAgentApp.Domain.Utils();
            if (util.userLogedOn()) {

                MainWindow ma = new MainWindow();
                ma.Show();
                this.Hide();

                //Go to the admin's Area
                //MessageBox.Show("yay");
            } else {
                //util.createDBEntities();
                //Prepare the DB here
                //ForceCursor creation of DB
            }*/
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            Dialog1.IsOpen = false;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            mIMEI = IMEI.Text.ToString();
            if (!mIMEI.Equals(string.Empty)) {
                Dialog1.IsOpen = false;
            } else {
                warningLab.Content = "Invalid device IMEI.";
            }
        }


        private void UIElement_OnMouseLeftButtonDown1(object sender, MouseButtonEventArgs e) {
            Dialog1.IsOpen = true;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e) {
            mIMEI = IMEI.Text.ToString();
            if (!mIMEI.Equals(string.Empty)) {
                Dialog1.IsOpen = false;
                statusMessage.Visibility = Visibility.Collapsed;
                IMEI.Text = String.Empty;
            } else {
                warningLab.Content = "Invalid device IMEI.";
                statusMessage.Visibility = Visibility.Visible;
                Dialog1.IsOpen = false;
            }
        }
    }
}
