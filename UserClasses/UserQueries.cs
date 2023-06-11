using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;
using Firebase.Auth;
using System.Windows;

namespace Coffee_to_go
{
    internal class UserQueries
    {
        private string pathToUsersFile;

        public UserQueries()
        {
            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var repositoryPath = pathInf.Parent.Parent.Parent.ToString();
            pathToUsersFile = Path.Combine(repositoryPath, "Data/users.bin");
        }

        private bool checkIfUserExists(User user)
        {
            if (user == null) return false;

            try
            {
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length == 0 || fs.Length == 1 || fs.Length == 2 || fs.Length == 3)
                        return false;

                    BinaryFormatter formatter = new BinaryFormatter();
                    User tmpUser;
                    while (fs.Position < fs.Length)
                    {
                        tmpUser = (User)formatter.Deserialize(fs);
                        if (tmpUser.id == user.id)
                            return true;
                    }
                    return false;
                }
            }
            catch (IOException ex)
            { throw new IOException("Couldn't check if the user exists"); }
        }

        public void addUserToSCV(User user)
        {
            if (!checkIfUserExists(user))
            {
                try
                {
                    using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Append))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, user);
                    }
                }
                catch (Exception ex) { throw new IOException("Couldn't add a new user"); }
            }
        }

        public List<User> getAllTheUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (fs.Position < fs.Length)
                    {
                        users.Add((User)formatter.Deserialize(fs));
                    }
                }
            }
            catch (Exception ex) { throw new IOException("Couldn't get all the users"); }

            return users;
        }

        public void changeUser(User userChange)
        {
            List<User> users = getAllTheUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].id == userChange.id)
                {
                    users[i] = userChange;
                    break;
                }
            }

            File.Delete(pathToUsersFile);

            try
            {
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    foreach (User user in users)
                    {
                        formatter.Serialize(fs, user);
                    }
                }
            }
            catch (Exception ex) { throw new IOException("Couldn't change user"); }
        }

        public void refreshUsers()
        {
            List<User> users = getAllTheUsers();

            for (int i = 0; i < users.Count;i++)
            {
                users[i] = new User(users[i].id, users[i].name, users[i].email);
            }

            File.Delete(pathToUsersFile);

            try
            {
                using (FileStream fs = new FileStream(pathToUsersFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    foreach (User user in users)
                    {
                        formatter.Serialize(fs, user);
                    }
                }
            }
            catch (Exception ex) { throw new IOException("Couldn't refresh users"); }
        }
    }
}
