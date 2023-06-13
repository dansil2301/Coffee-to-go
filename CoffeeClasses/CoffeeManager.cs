using OpenQA.Selenium.DevTools.V112.Runtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class CoffeeManager
    {
        private CoffeePrices _prices = new CoffeePrices();
        private GlobalCoffeeHistrory globalCoffeeHistrory = new GlobalCoffeeHistrory();

        public double countSumToPay(string sizeIn, string typeIn, string specialIn, string extrasIn)
        {
            return (sizeIn == string.Empty ? 0 : _prices.size[sizeIn]) + (typeIn == string.Empty ? 0 : _prices.types[typeIn]) + 
                   (specialIn == string.Empty ? 0 : _prices.special[specialIn]) + (extrasIn == string.Empty ? 0 : _prices.extras[extrasIn]);
        }

        public void addHistoryItem(User user, string sizeIn, string typeIn, string specialIn, string extrasIn, bool voucherPayIn)
        {
            if (sizeIn == null || typeIn == null || specialIn == null || extrasIn == null) { throw new NullReferenceException("Null is not allowed"); }

            CoffeeInf coffee = new CoffeeInf();
            coffee.userId = user.id;
            coffee.type = typeIn;
            coffee.special = specialIn;
            coffee.extras = extrasIn;
            coffee.size = sizeIn;
            coffee.voucherPay = voucherPayIn;
            coffee.buyTime = DateTime.Now;
            coffee.price = countSumToPay(sizeIn, typeIn, specialIn, extrasIn);

            globalCoffeeHistrory.addCoffeeToHistory(coffee);
            user.addHistory(coffee);
        }

        public List<CoffeeInf> GetCoffeeHistory()
        {
            return globalCoffeeHistrory.getCoffeeHistory();
        }

        public double GetUserTotal(User user)
        {
            double total = 0;

            foreach (var item in user.GetHistory)
            {
                if (!item.voucherPay)
                { total += item.price; }
            }

            return total;
        }

        public double GetUserTotalMonth(User user)
        {
            double total = 0;
            var now = DateTime.Now;

            foreach (var item in user.GetHistory)
            {
                if (now.Month == item.buyTime.Month && !item.voucherPay)
                { total += item.price; }
            }

            return total;
        }

        public double GetAllTotal()
        {
            double total = 0;
            var all = globalCoffeeHistrory.getCoffeeHistory();

            foreach (var item in all)
            {
                if (!item.voucherPay)
                { total += item.price; }
            }

            return total;
        }

        public double GetAllTotalMonth()
        {
            double total = 0;
            var now = DateTime.Now;
            var all = globalCoffeeHistrory.getCoffeeHistory();

            foreach (var item in all)
            {

                if (now.Month == item.buyTime.Month && !item.voucherPay)
                { total += item.price; }
            }

            return total;
        }
    }
}
