using Coffee_to_go.Authentication.AuthenticationLogic;
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
    /// Логика взаимодействия для EmailSignIn.xaml
    /// </summary>
    public partial class EmailSignIn : Window
    {
        private EmailAuth emailAuth = new EmailAuth();

        public EmailSignIn()
        {
            InitializeComponent();
        }

        private void redirectToMain()
        {
            Window main = new MainWindow();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Show();
            this.Close();
        }

        private async void signIn_Click(object sender, RoutedEventArgs e)
        {
            bool exists = await emailAuth.UserExist(emailTxtBx.Text);

            if (!exists)
            {
                signInGrid.Visibility = Visibility.Hidden;
                registerGrid.Visibility = Visibility.Visible;
            }
            else
            {
                signInGrid.Visibility = Visibility.Visible;
                registerGrid.Visibility = Visibility.Hidden;

                try
                {
                    await emailAuth.FindUserAndSaveCred(emailTxtBx.Text, passwordTxtBx.Password);
                    redirectToMain();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private async void signUp_Click(object sender, RoutedEventArgs e)
        {
            await emailAuth.createUserAndSaveCred(regEmailTxtBx.Text, regPasswordTxtBx.Password, regNameTxtBx.Text);
            redirectToMain();
        }
    }
}
