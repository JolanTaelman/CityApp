using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;

namespace MvvmLight1.ViewModel
{
    public class LoginPageViewModel
    {
        private readonly INavigationService _navigationService;
      


        public LoginPageViewModel(
            INavigationService navigationService)
        {
            
            _navigationService = navigationService;
            
        }

}
}