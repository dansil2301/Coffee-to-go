using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Coffee_to_go
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrentUserFIleWork currentUserFIleWork = new CurrentUserFIleWork();
        private UserManager userManager = new UserManager();
        private CoffeePrices coffeePrices = new CoffeePrices();
        private CoffeeManager coffeeManager = new CoffeeManager();
        private User user;

        private double purchaseSum = 0;

        public MainWindow()
        {
            InitializeComponent();
            userManager.refreshUsers(); //uncomment if user class has changed

            var data = currentUserFIleWork.GetUser();
            user = new User(data.id, data.displayName, data.email);
            userManager.AddUser(user);
            user = userManager.refeshCurrentUser(user);

            setUserInf();
            setCoffeeInf();
        }

        private void showGridHideOthers(string name)
        {
            foreach (var child in mainGrid.Children)
            {
                if (child is Grid grid && !string.IsNullOrEmpty(grid.Name))
                {
                    if (grid.Name == name)
                    { grid.Visibility = Visibility.Visible; }
                    else 
                    { grid.Visibility = Visibility.Hidden; }
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            currentUserFIleWork.DeleteUser();
            Window Login = new LoginWindow();
            Login.Show();
            this.Close();
        }

        private void account_Click(object sender, RoutedEventArgs e)
        {
            showGridHideOthers("Account");
            SelectedTab.Text = "Account";
        }

        private void setUserInf()
        {
            displayName.Text = user.name;
            emailAcc.Text = user.email;
        }

        private void getVoucher_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            showGridHideOthers("BuyCoffee");
            SelectedTab.Text = "Buy Coffee";
        }

        private void setCoffeeInf ()
        {
            foreach (var size in coffeePrices.size.Keys)
            { sizeLstBx.Items.Add(size); }

            foreach (var coffee in coffeePrices.types.Keys)
            { typeLstBx.Items.Add(coffee); }

            foreach (var special in coffeePrices.special.Keys)
            { specialLstBx.Items.Add(special); }

            foreach (var extra in coffeePrices.extras.Keys)
            { extrasLstBx.Items.Add(extra); }
        }

        private void payWithVoucher_Click(object sender, RoutedEventArgs e)
        {

        }

        private void payMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string size = sizeLstBx.SelectedItem != null ? sizeLstBx.SelectedItem.ToString() : null;
                string type = typeLstBx.SelectedItem != null ? typeLstBx.SelectedItem.ToString() : null;
                string extra = extrasLstBx.SelectedItem != null ? extrasLstBx.SelectedItem.ToString() : null;
                string special = specialLstBx.SelectedItem != null ? specialLstBx.SelectedItem.ToString() : null;

                coffeeManager.addHistoryItem(user, size, type, special, extra, false);
                purchaseSum = 0;
                MessageBox.Show(user.GetHistory.Count().ToString());
            }
            catch(NullReferenceException ex) 
            { MessageBox.Show("Select item in all boxes to purchase"); }
        }

        // a little logic but its UI logic no sense to put it in a different place
        private void totalSum()
        {
            //number.HasValue ? number.Value : 0;
            purchaseSum = (sizeLstBx.SelectedItem == null ? 0 : coffeePrices.size[sizeLstBx.SelectedItem.ToString()]) +
                          (typeLstBx.SelectedItem == null ? 0 : coffeePrices.types[typeLstBx.SelectedItem.ToString()]) +
                          (specialLstBx.SelectedItem == null ? 0 : coffeePrices.special[specialLstBx.SelectedItem.ToString()]) +
                          (extrasLstBx.SelectedItem == null ? 0 : coffeePrices.extras[extrasLstBx.SelectedItem.ToString()]);
            
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string size = sizeLstBx.SelectedItem != null ? sizeLstBx.SelectedItem.ToString() : string.Empty;
            string type = typeLstBx.SelectedItem != null ? typeLstBx.SelectedItem.ToString() : string.Empty;
            string extra = extrasLstBx.SelectedItem != null ? extrasLstBx.SelectedItem.ToString() : string.Empty;
            string special = specialLstBx.SelectedItem != null ? specialLstBx.SelectedItem.ToString() : string.Empty;

            amountToPay.Text = "Amount: " + coffeeManager.countSumToPay(size, type, special, extra).ToString();
        }
    }
}
