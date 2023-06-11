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

        public double countSumToPay(string sizeIn, string typeIn, string specialIn, string extrasIn)
        {
            //return _prices.size[sizeIn] + _prices.types[typeIn] + _prices.special[specialIn] + _prices.extras[extrasIn];

            return (sizeIn == string.Empty ? 0 : _prices.size[sizeIn]) + (typeIn == string.Empty ? 0 : _prices.types[typeIn]) + 
                   (specialIn == string.Empty ? 0 : _prices.special[specialIn]) + (extrasIn == string.Empty ? 0 : _prices.extras[extrasIn]);
        }

        public void addHistoryItem(User user, string sizeIn, string typeIn, string specialIn, string extrasIn, bool voucherPayIn)
        {
            if (sizeIn == null || typeIn == null || specialIn == null || extrasIn == null) { throw new NullReferenceException("Null is not allowed"); }

            CoffeeInf coffee = new CoffeeInf();
            coffee.type = typeIn;
            coffee.special = specialIn;
            coffee.extras = extrasIn;
            coffee.size = sizeIn;
            coffee.price = countSumToPay(sizeIn, typeIn, specialIn, extrasIn);

            user.addHistory(coffee);
        }
    }
}
