import { initializeApp } from "https://www.gstatic.com/firebasejs/9.22.1/firebase-app.js";
import { getAnalytics } from "https://www.gstatic.com/firebasejs/9.22.1/firebase-analytics.js";
import { GoogleAuthProvider, getRedirectResult, signInWithRedirect, getAuth, onAuthStateChanged } from "https://www.gstatic.com/firebasejs/9.22.1/firebase-auth.js";

class FirebaseGoogleAuth
{
    firebaseConfig = {
    apiKey: "AIzaSyAktAewDe5azdwg03cBLDMI7g3w9Ar8Hhk",
    authDomain: "coffee-to-go-fontys.firebaseapp.com",
    projectId: "coffee-to-go-fontys",
    storageBucket: "coffee-to-go-fontys.appspot.com",
    messagingSenderId: "1098730864304",
    appId: "1:1098730864304:web:cce282d13ccf2fb2078575",
    measurementId: "G-MQRDSPT978"
    };

    app = initializeApp(this.firebaseConfig);
    analytics = getAnalytics(this.app);
    provider = new GoogleAuthProvider();

    googleSignIn = function () {
        const auth = getAuth();
        signInWithRedirect(auth, this.provider);
        FirebaseGoogleAuth.getCred(auth);
    }

    static sendUserInf(user_id=null, email=null, displayName=null) {
        $.ajax({
            data: {
                'user_id': user_id,
                'displayName': displayName,
                'email': email
            },
            type: 'POST',
            url: '/save_user_inf'
        })
            .done(function (data){
                if (data['success']) {
                    console.log("Success");
                }
            });
    }

    static getCred(auth) {
        getRedirectResult(auth)
          .then((result) => {
            const credential = GoogleAuthProvider.credentialFromResult(result);
            const token = credential.accessToken;
            const user = result.user;
            window.location.replace("http://127.0.0.1:5000/callback");
          }).catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            const credential = GoogleAuthProvider.credentialFromError(error);
          });
    }
}

function google_sign(){
    const firebaseGoogleAuth = new FirebaseGoogleAuth();
    firebaseGoogleAuth.googleSignIn();
}

// sign in everytime
google_sign();

const auth = getAuth();
onAuthStateChanged(auth, (user) => {
    if (user) {
        FirebaseGoogleAuth.sendUserInf(user.uid, user.email, user.displayName);
    }
});
