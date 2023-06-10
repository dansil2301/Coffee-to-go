using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;
using System.Text.Json;

namespace Coffee_to_go
{
    internal class SaveUserCred
    {
        public void saveUser(string idIn, string emailIn, string displayNameIn)
        {
            var data = new
            {
                id = idIn,
                email = emailIn,
                displayName = displayNameIn
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var repositoryPath = pathInf.Parent.Parent.Parent.ToString();
            var absolutePath = Path.Combine(repositoryPath, "Authentication/current_user/current_user.json");

            File.WriteAllText(absolutePath, json);
        }
    }
}
