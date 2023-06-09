using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Coffee_to_go
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            FirebaseUI.Initialize(new FirebaseUIConfig
            {
                ApiKey = "AIzaSyAktAewDe5azdwg03cBLDMI7g3w9Ar8Hhk",
                AuthDomain = "coffee-to-go-fontys.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new GoogleProvider(),
                    new EmailProvider()
                },
                PrivacyPolicyUrl = "https://github.com/step-up-labs/firebase-authentication-dotnet",
                TermsOfServiceUrl = "https://github.com/step-up-labs/firebase-database-dotnet",
                IsAnonymousAllowed = false,
                UserRepository = new FileUserRepository("coffee go")
            });
        }
    }
}
