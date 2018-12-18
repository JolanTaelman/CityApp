using MvvmLight1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MvvmLight1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        ObservableCollection<String> categories = new ObservableCollection<String>();
        ObservableCollection<Business> ondernemingen = new ObservableCollection<Business>();

        ObservableCollection<Business> filteredBusinesses = new ObservableCollection<Business>();

        public Home()
        {
            categories.Add("geen categorie");
            categories.Add("Restaurant");
            categories.Add("Winkel");
            categories.Add("Cafe");
            ondernemingen.Add(new Business { Category = "Restaurant", Name = "Pizza Frank" });
            ondernemingen.Add(new Business { Category = "Winkel", Name = "Okay Gent" });
            ondernemingen.Add(new Business { Category = "Cafe", Name = "Cafe bob" });
            filteredBusinesses.Add(new Business { Category = "Restaurant", Name = "Pizza Frank" });
            filteredBusinesses.Add(new Business { Category = "Winkel", Name = "Okay Gent" });
            filteredBusinesses.Add(new Business { Category = "Cafe", Name = "Cafe bob" });
            this.InitializeComponent();
        }


        public void Home_ItemClick(object sender, ItemClickEventArgs args)
        {
            gekozenBusiness.Name = "Arno";
        }

        private void GekozenBusiness_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Get selected item of Combobox
            string selectedItem = (String)cbCategorie.SelectedItem;
            
            // use filter method
            FilterBusiness(selectedItem);
        }

        public void FilterBusiness(string categorie)
        {
            filteredBusinesses.Clear();
            var b = new List<Business>();
            b = ondernemingen.Where(o => o.Category == categorie).ToList();

            if (categorie == "geen categorie")
            {
                filteredBusinesses.Add(new Business { Category = "Restaurant", Name = "Pizza Frank" });
                filteredBusinesses.Add(new Business { Category = "Winkel", Name = "Okay Gent" });
                filteredBusinesses.Add(new Business { Category = "Cafe", Name = "Cafe bob" });
            }
            else
            {
                if (b.Count() > 0)
                {
                    b.ForEach(bus => filteredBusinesses.Add(bus));
                }
            }
        }
    }
}
