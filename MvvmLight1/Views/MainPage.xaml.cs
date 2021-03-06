﻿using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using MvvmLight1.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using Windows.UI.Popups;
using Firebase.Auth;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Views;

namespace MvvmLight1
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;
        
        public MainPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;
            
            Loaded += (s, e) =>
            {
                Vm.RunClock();
            };
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Vm.StopClock();
            base.OnNavigatingFrom(e);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });*/

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {/*
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);*/

                 ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }

        private async void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                
                case "Home":
                    ContentFrame.Navigate(typeof(Views.Home));
                    break;
                case "Profiel":
                    ContentFrame.Navigate(typeof(Views.Profiel));
                    break;
                case "settings":
                    ContentFrame.Navigate(typeof(SettingsPage));
                    break;
                case "Bedrijf toevoegen":
                    ContentFrame.Navigate(typeof(Views.RegistreerBusiness));
                    break;
                case "Uitloggen":
                    var messageDialog = new MessageDialog("Wil je uitloggen?");
                    var yesCommand = new UICommand("Uitloggen", cmd => { });
                    var cancelCommand = new UICommand("Sluiten", cmd => { });
                   messageDialog.Commands.Add(yesCommand);
                    messageDialog.Commands.Add(cancelCommand);

                    messageDialog.DefaultCommandIndex = 0;
                    
                   var command =  await messageDialog.ShowAsync();
                    if (command == yesCommand)
                    {
                        var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                        nav.NavigateTo(ViewModelLocator.loginKey);
                       // ContentFrame.Navigate(typeof(Views.LoginPage));
                    }
                    else
                    {
                        messageDialog.CancelCommandIndex = 1;
                        
                    }
                    break;

            }
        }

    }
}
