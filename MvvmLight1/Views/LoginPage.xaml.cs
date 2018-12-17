using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.ViewModel;


namespace MvvmLight1.Views
{
    public sealed partial class LoginPage : Page
    {
       

        public LoginPage()
        {
            InitializeComponent();
            ContentFrame.Navigate(typeof(login));
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;
            //  SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

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
                if (item is NavigationViewItem && item.Tag.ToString() == "Login")
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

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Login":
                    ContentFrame.Navigate(typeof(login));
                    break;
                case "Register":
                    ContentFrame.Navigate(typeof(Register));
                    break;
                case "Home":
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(ViewModelLocator.anoniemMainpageKey);
                    break;
            }
        }

    }
}
