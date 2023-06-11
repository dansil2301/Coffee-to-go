using OpenQA.Selenium.DevTools.V112.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    [Serializable]
    internal class User
    {
        public string id { private set; get; }
        public string name { private set; get; }
        public string email { private set; get; }
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
            AddStreak();
        }

        public void AddStreak()
        {
            if (currentStreak < 10)
                currentStreak++;
        }

        public void Streak()
        {
            currentStreak = 0;
        }
    }
}
