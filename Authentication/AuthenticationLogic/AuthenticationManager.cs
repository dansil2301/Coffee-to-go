using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class AuthenticationManager
    {
        private GoogleAuth googleAuth = new GoogleAuth();

        public bool UserLoggedIn()
        {
            var pathInf = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var repositoryPath = pathInf.Parent.Parent.Parent.ToString();
            var absolutePath = Path.Combine(repositoryPath, "Authentication/current_user/current_user.json");

            return File.Exists(absolutePath);
        }

        public void SignInWithGoogle()
        {
            googleAuth.getUser();
        }
    }
}
