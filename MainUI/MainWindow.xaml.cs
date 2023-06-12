using Firebase.Auth;
using OpenQA.Selenium.DevTools.V112.Tracing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private VoucherGenerator voucherGenerator = new VoucherGenerator();
        private User user;

        public ObservableCollection<string> historyItems { set; get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            userManager.refreshUsers(); //uncomment if user class has changed

            var data = currentUserFIleWork.GetUser();
            user = new User(data.id, data.displayName, data.email);
            userManager.AddUser(user);
            user = userManager.refeshCurrentUser(user);

            historyItems = new ObservableCollection<string>();

            setUserInf();
            setCoffeeInf();
            showHistory();
            showStreak();
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
            GetVoucherWindow confirm = new GetVoucherWindow(user);
            confirm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            confirm.ShowDialog();

            switch (confirm.GetInf)
            {
                case "accepted":
                    voucherGenerator.setVoucher(user);
                    user.ResetStreak();
                    break;
            }
            userManager.changeUser(user);

            showStreak();
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

        private void showStreak()
        {
            coffeeStreak.Text = user.GetCurrentStreak.ToString();
            coffeeStreakBuyCoffee.Text = user.GetCurrentStreak.ToString();
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
                userManager.changeUser(user);

                showStreak();
            }
            catch(NullReferenceException ex) 
            { MessageBox.Show("Select item in all boxes to purchase"); }
            showHistory();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string size = sizeLstBx.SelectedItem != null ? sizeLstBx.SelectedItem.ToString() : string.Empty;
            string type = typeLstBx.SelectedItem != null ? typeLstBx.SelectedItem.ToString() : string.Empty;
            string extra = extrasLstBx.SelectedItem != null ? extrasLstBx.SelectedItem.ToString() : string.Empty;
            string special = specialLstBx.SelectedItem != null ? specialLstBx.SelectedItem.ToString() : string.Empty;

            amountToPay.Text = "Amount: " + coffeeManager.countSumToPay(size, type, special, extra).ToString();
        }

        private void showHistory()
        {
            historyItems.Clear();

            foreach (var item in user.GetHistory)
            {
                historyItems.Add($"type: {item.type}, Size: {item.size[0]}, Special: {item.special}, Extra: {item.extras} ({item.price})");
            }
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            showGridHideOthers("History");
            SelectedTab.Text = "History";
        }

        private void PreventDef(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
