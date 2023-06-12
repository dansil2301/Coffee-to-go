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
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Append))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, coffee);
                }
            }
            catch (Exception ex) { throw new IOException("Couldn't add history item"); }
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
