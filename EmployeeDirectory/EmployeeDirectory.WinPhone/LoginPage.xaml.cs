using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using EmployeeDirectory.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace EmployeeDirectory.WinPhone {
    public partial class LoginPage : PhoneApplicationPage {
        readonly LoginViewModel loginViewModel;
        public LoginPage ()
        {
            InitializeComponent ();

            loginViewModel = new LoginViewModel (App.Current.DirectoryService);

            DataContext = loginViewModel;

            username.TextChanged += (sender, e) => loginViewModel.Username = username.Text;
            password.PasswordChanged += (sender, e) => loginViewModel.Password = password.Password;
            loginButton.Click += (sender, e) => Login ();
            helpLogin.Click += (sender, e) => {
                MessageBox.Show ("Enter any username or password.", "Need Help?", MessageBoxButton.OK);
                };
        }

        protected override void OnNavigatedTo (NavigationEventArgs e)
        {
            base.OnNavigatedTo (e);

            username.Text = string.Empty;
            password.Password = string.Empty;
        }

        private void Login ()
        {
            if (!string.IsNullOrEmpty (username.Text) && !string.IsNullOrEmpty (password.Password)) {
                loginViewModel
                    .LoginAsync (System.Threading.CancellationToken.None)
                    .ContinueWith (_ => {
                        Dispatcher.BeginInvoke (() => {
                            NavigationService.Navigate (new Uri ("/MainPage.xaml", UriKind.Relative));
                        });
                    });
            }
        }

        protected override void OnKeyDown (System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) {
                e.Handled = true;
                if (string.IsNullOrEmpty (password.Password) && FocusManager.GetFocusedElement () is TextBox) {
                    password.Focus ();
                    e.Handled = true;
                } else {
                    this.Focus ();
                    Login ();
                }
            }

            base.OnKeyDown (e);
        }
    }
}