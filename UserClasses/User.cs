using OpenQA.Selenium.DevTools.V112.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    [Serializable]
    public class User
    {
        public string id { private set; get; }
        public string name { private set; get; }
        public string email { private set; get; }
        public string voucherType;
        public Dictionary<string, string> voucher = new Dictionary<string, string>();

        private int currentStreak = 0;
        private List<CoffeeInf> history = new List<CoffeeInf>();

        public int GetCurrentStreak => currentStreak;
        public List<CoffeeInf> GetHistory => history;

        public User(string idIn, string nameIn, string emailin) 
        {
            id = idIn;
            name = nameIn;
            email = emailin;
        }

        public void addHistory(CoffeeInf coffee)
        {
            history.Add(coffee);
            if (voucher.Count == 0)
            { AddStreak(); }
        }

        private void AddStreak()
        {
            if (currentStreak < 10)
                currentStreak++;
        }

        public void ResetStreak()
        {
            currentStreak = 0;
        }
    }
}
