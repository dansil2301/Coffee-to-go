using Coffee_to_go.Authentication;
using OpenQA.Selenium.DevTools.V112.Page;
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
using System.Windows.Shapes;

namespace Coffee_to_go
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private AuthenticationManager _manager = new AuthenticationManager();

        public LoginWindow()
        {
            InitializeComponent();

            if (_manager.UserLoggedIn())
            { redirectToMain(); }
        }

        private void redirectToMain()
        {
            Window main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void google_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
                this.IsHitTestVisible = false;

                _manager.SignInWithGoogle();

                redirectToMain();
            }
            catch (Exception ex) 
            {
                this.WindowState = WindowState.Normal;
                this.IsHitTestVisible = true;
                MessageBox.Show("Authentication error: Try again");
            }
        }

        private void email_Click(object sender, RoutedEventArgs e)
        {
            Window emailSignIn = new EmailSignIn();
            emailSignIn.Show();
            this.Close();
        }
    }
}
