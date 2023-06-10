using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Cryptography;

namespace Coffee_to_go.Authentication.AuthenticationLogic
{
    internal class EmailAuth
    {
        SaveUserCred SaveUserCred = new SaveUserCred();
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

        public async void createUserAndSaveCred(string email, string password, string displayName)
        {
            var user = await client.CreateUserWithEmailAndPasswordAsync(email, password, displayName);
            SaveUserCred.saveUser(user.User.Uid, email, displayName);
        }

        public async void FindUserAndSaveCred(string email, string password)
        {
            var user = await client.SignInWithEmailAndPasswordAsync(email, password);
            SaveUserCred.saveUser(user.User.Uid, email, user.User.Info.DisplayName);
        }
    }
}
