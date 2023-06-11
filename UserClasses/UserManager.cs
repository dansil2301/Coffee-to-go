using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class UserManager
    {
        private UserQueries userQueries = new UserQueries();

        public List<User> GetUserList()
        {
            return userQueries.getAllTheUsers();
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException("User is null");
            userQueries.addUserToSCV(user);
        }

        public void changeUser(User user)
        {
            userQueries.changeUser(user);
        }

        public void refreshUsers()
        {
            userQueries.refreshUsers();
        }

        public User refeshCurrentUser(User user)
        {
            foreach (User userIter in userQueries.getAllTheUsers())
            {
                if (user.id == userIter.id)
                {
                    user = userIter;
                }
            }
            return user;
        }
    }
}
