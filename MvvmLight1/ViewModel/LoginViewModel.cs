
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Firebase.Auth;
using GalaSoft.MvvmLight;
using MvvmLight1.Model;
using MvvmLight1.Utils;

namespace MvvmLight1.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public RelayCommand LoginCommand { get; set; }
        public LoginModel Login { get; set; }

        public string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged("username"); }
        }

        public string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("password"); }
        }

        public LoginViewModel()
        {
            
            LoginCommand = new RelayCommand((p) => LoginAccount(new LoginModel(){Username = username,Password = password}));

        }

        private async Task LoginAccount(object p)
        {
            
            if (p is LoginModel)
            {
                LoginModel x = (LoginModel)p;
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBcaljUunX_ReEAFzqXUImLTYJsw1x7a7s"));

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(x.Username, x.Password);
                
                Debug.WriteLine(auth.FirebaseToken);
            }
        }

        
    }

}

