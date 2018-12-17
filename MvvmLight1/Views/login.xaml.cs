using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Firebase.Auth;
using GalaSoft.MvvmLight.Ioc;
using MvvmLight1.Model;
using MvvmLight1.ViewModel;
using MvvmLight1.Views;


namespace MvvmLight1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///  private readonly INavigationService _navigationService;
    public sealed partial class login : Page
    {
        public MainViewModel Vm => (MainViewModel)DataContext;
        public INavigationService nav;
        public login()
        {
            this.InitializeComponent();
            nav = ServiceLocator.Current.GetInstance<INavigationService>();
        }

        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
           
            nav.GoBack();
        }

        private void AnoniemLogin_Click(object sender, RoutedEventArgs e)
        {
            
            
            nav.NavigateTo(ViewModelLocator.mainpageKey);
            
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBcaljUunX_ReEAFzqXUImLTYJsw1x7a7s"));
                FirebaseAuth auth = await authProvider.SignInWithEmailAndPasswordAsync(in_email.Text, in_password.Password);
                nav.NavigateTo(ViewModelLocator.mainpageKey);

            }
            catch (Exception es)
            {
                var messageDialog = new MessageDialog("Account ongeldig");
                messageDialog.Commands.Add(new UICommand("Sluiten"));
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
           }
            
            
         
            
          



        }


    }
}
