using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Cryptography;
using System.IO;

namespace Coffee_to_go.Authentication.AuthenticationLogic
{
    internal class EmailAuth
    {
        CurrentUserFIleWork SaveUserCred = new CurrentUserFIleWork();
        FirebaseAuthClient client;

        public EmailAuth() 
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyAktAewDe5azdwg03cBLDMI7g3w9Ar8Hhk",
                AuthDomain = "coffee-to-go-fontys.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            client = new FirebaseAuthClient(config);
        }

        public async Task<bool> UserExist(string email)
        {
            var result = await client.FetchSignInMethodsForEmailAsync(email);

            if (result.UserExists)
            { return true; }
            return false;
        }

        public async Task createUserAndSaveCred(string email, string password, string displayName)
        {
            var user = await client.CreateUserWithEmailAndPasswordAsync(email, password, displayName);
            SaveUserCred.SaveUser(user.User.Uid, email, displayName);
        }

        public async Task FindUserAndSaveCred(string email, string password)
        {
            try
            {
                var user = await client.SignInWithEmailAndPasswordAsync(email, password);
                SaveUserCred.SaveUser(user.User.Uid, email, user.User.Info.DisplayName);
            }
            catch
            { throw new IOException("Wrong password"); }
        }
    }
}
