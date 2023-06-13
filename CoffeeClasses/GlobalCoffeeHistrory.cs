using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class GlobalCoffeeHistrory
    {
        private string pathToUsersFile;

        public GlobalCoffeeHistrory()
        {
            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var repositoryPath = pathInf.Parent.Parent.Parent.ToString();
            pathToUsersFile = Path.Combine(repositoryPath, "Data/history.bin");
        }

        public void addCoffeeToHistory(CoffeeInf coffee)
        {
            try
            {
                List<CoffeeInf> coffees = getCoffeeHistory();

                coffees.Insert(0, coffee);

                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    foreach (var coffe in coffees)
                    {
                        formatter.Serialize(fs, coffe);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Couldn't add history item", ex);
            }
        }

        public List<CoffeeInf> getCoffeeHistory()
        {
            List<CoffeeInf> coffees = new List<CoffeeInf>();

            try
            {
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (fs.Position < fs.Length)
                    {
                        coffees.Add((CoffeeInf)formatter.Deserialize(fs));
                    }
                }
            }
            catch (Exception ex) { throw new IOException("Couldn't get History"); }

            return coffees;
        }

    }
}
