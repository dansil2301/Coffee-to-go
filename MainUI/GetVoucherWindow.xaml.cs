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
    /// Логика взаимодействия для GetVoucherWindow.xaml
    /// </summary>
    public partial class GetVoucherWindow : Window
    {
        private VoucherGenerator voucherGenerator = new VoucherGenerator();
        public string GetInf;


        public GetVoucherWindow(User user)
        {
            InitializeComponent();

            GetInf = "";
            voucherText.Text = $"You will get {voucherGenerator.GetVoucherNameByStreak(user)} voucher";

            if (voucherGenerator.isStreakBigEnough(user))
            {
                ConfirmGrid.Visibility = Visibility.Visible;
                NotEnoughGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                ConfirmGrid.Visibility = Visibility.Hidden;
                NotEnoughGrid.Visibility = Visibility.Visible;
            }
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "accepted";
            Close();
        }

        private void decline_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "declined";
            Close();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            GetInf = "ok";
            Close();
        }


    }
}
