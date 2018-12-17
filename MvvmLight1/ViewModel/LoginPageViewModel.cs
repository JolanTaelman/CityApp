using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;

namespace MvvmLight1.ViewModel
{
    public class LoginPageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand<string> _navigateLogin;


        public LoginPageViewModel(
            INavigationService navigationService)
        {
            
            _navigationService = navigationService;
            
        }

        public RelayCommand<string> NavigateLogin
        {
            get
            {
                return _navigateLogin ?? (
                           _navigateLogin = new RelayCommand<string>(

                               p => _navigationService.NavigateTo(ViewModelLocator.mainpageKey, p),
                               p => !string.IsNullOrEmpty(p)));
            }
        }

    }
}