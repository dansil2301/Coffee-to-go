using OpenQA.Selenium.DevTools.V113.CSS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    [Serializable]
    public class CoffeeInf
    {
        public string size { get; set; }
        public string type { get; set; }
        public string special { get; set; }
        public string extras { get; set; }
        public double price { get; set; }
        public bool voucherPay { get; set; }
        public DateTime buyTime { get; set; }
    }
}
