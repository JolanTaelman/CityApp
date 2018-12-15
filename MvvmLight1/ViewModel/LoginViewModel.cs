
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Firebase.Auth;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;
using RelayCommand = MvvmLight1.Utils.RelayCommand;

namespace MvvmLight1.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand NavigationCommand { get; set; }
        private RelayCommand<string> _navigateCommand;
        private readonly INavigationService _navigationService;
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
                try
                {
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(x.Username, x.Password);
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(ViewModelLocator.mainpageKey);
                }
                catch (Exception e)
                {
                    var messageDialog = new MessageDialog("Account ongeldig");
                    messageDialog.Commands.Add(new UICommand("Sluiten"));


                    messageDialog.CancelCommandIndex = 1;
                    await messageDialog.ShowAsync();
                }
                

               
            }
        }

        
    }

}

