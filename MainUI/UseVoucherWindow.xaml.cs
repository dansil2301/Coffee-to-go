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
    /// Логика взаимодействия для UseVoucherWindow.xaml
    /// </summary>
    public partial class UseVoucherWindow : Window
    {
        public string GetInf;

        public UseVoucherWindow(User user)
        {
            InitializeComponent();


            GetInf = "";
            voucherText.Text = $"Your {user.voucherType} voucher will be used";

            if (user.voucherType == "")
            {
                NoVoucherGrid.Visibility = Visibility.Visible;
                ConfirmGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                NoVoucherGrid.Visibility = Visibility.Hidden;
                ConfirmGrid.Visibility = Visibility.Visible;
            }
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "accepted";
            Close();
        }

        private void decline_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "decline";
            Close();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "ok";
            Close();
        }
    }
}
