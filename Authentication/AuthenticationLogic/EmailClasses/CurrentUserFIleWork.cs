using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;
using System.Text.Json;
using Firebase.Auth.Requests;
using System.Security.Cryptography.X509Certificates;

namespace Coffee_to_go
{
    public class Data
    {
        public string id { get; set; }
        public string email { get; set; }
        public string displayName { get; set; }
    }


    internal class CurrentUserFIleWork
    {
        private string absolutePath;
        private Data data = new Data();

        public CurrentUserFIleWork()
        {
            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var repositoryPath = pathInf.Parent.Parent.Parent.ToString();
            absolutePath = Path.Combine(repositoryPath, "Authentication/current_user/current_user.json");
        }

        public void SaveUser(string idIn, string emailIn, string displayNameIn)
        {
            data.id = idIn;
            data.email = emailIn;
            data.displayName = displayNameIn;

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(absolutePath, json);
        }

         public Data GetUser() 
        {
            string json = File.ReadAllText(absolutePath);
            data = JsonSerializer.Deserialize<Data>(json);
            return data;
        }

        public void DeleteUser()
        {
            File.Delete(absolutePath);
        }
    }
}
