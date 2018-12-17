using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Firebase.Auth;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MvvmLight1.Model;
using Newtonsoft.Json;
using RelayCommand = MvvmLight1.Utils.RelayCommand;
using User = MvvmLight1.Model.User;

namespace MvvmLight1.ViewModel
{
    
    public class RegisterViewModel : ViewModelBase
    {

        public RegisterModel Register { get; set; }
        public RelayCommand RegisterCommand { get; set; }

        public string _username;

        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("username");
            }
        }

        public string _password;

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("password");
            }
        }

        public string _adress1;

        public string adres1
        {
            get { return _adress1; }
            set
            {
                _adress1 = value;
                RaisePropertyChanged("adres1");
            }
        }

        public string _adress2;

        public string adress2
        {
            get { return _adress2; }
            set
            {
                _adress2 = value;
                RaisePropertyChanged("adres2");
            }
        }

        public string _gemeente;

        public string gemeente
        {
            get { return _gemeente; }
            set
            {
                _gemeente = value;
                RaisePropertyChanged("gemeente");
            }
        }

        public string _postcode;

        public string postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                RaisePropertyChanged("postcode");
            }
        }

        private ObservableCollection<string> _staatLijst = new ObservableCollection<string>();

        public ObservableCollection<string> staatLijst
        {
            get { return _staatLijst; }
            set
            {
                _staatLijst = value;
                RaisePropertyChanged("staatlijst");
            }
        }

        private string _staat;

        public string staat
        {
            get { return _staat; }
            set
            {
                _staat = value;
                RaisePropertyChanged("staat");
            }
        }

        public string _email;

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("email");
            }
        }

        public RegisterViewModel()
        {
            staatLijst = new ObservableCollection<string>()
            {
                "West-Vlaanderen",
                "Oost-Vlaanderen",
                "Antwerpen",
                "Limburg",
                "Waals - Brabant",
                "Vlaams - Brabant",
                "Henegouwen",
                "Luik",
                "Luxemburg",
                "Namen"
            };

            RegisterCommand = new RelayCommand(async (p) => await RegisterAccount(new RegisterModel()
            {
                Username = username,
                Passwoord = password,
                Adres1 = adres1,
                Adres2 = adress2,
                Email = email,
                Gemeente = gemeente,
                Postcode = postcode,
                Staat = staat
            }));

        }

        public async Task RegisterAccount(object p)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBcaljUunX_ReEAFzqXUImLTYJsw1x7a7s"));
            if (p is RegisterModel)
            {
                RegisterModel rm = (RegisterModel) p;
                HttpClient client = new HttpClient();
                try
                {
                    var test = await authProvider.CreateUserWithEmailAndPasswordAsync(rm.Email, rm.Passwoord);
                    var messageDialog = new MessageDialog("Account geregistreerd");
                    messageDialog.Commands.Add(new UICommand("Sluiten"));
                    messageDialog.CancelCommandIndex = 1;
                    await messageDialog.ShowAsync();
                }
                catch (Exception e)
                {
                    var messageDialog = new MessageDialog("Account bestaat al");
                    messageDialog.Commands.Add(new UICommand("Sluiten"));
                    messageDialog.CancelCommandIndex = 1;
                    await messageDialog.ShowAsync();

                }
               
               
            }

        }

    }
}