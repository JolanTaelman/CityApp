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
        ObservableCollection<Business> businesses = new ObservableCollection<Business>();

        ObservableCollection<Business> filteredBusinesses { get; set; }

       

        public Home()
        {
            categories.Add("geen categorie");
            categories.Add("Restaurant");
            categories.Add("Winkel");
            categories.Add("Cafe");
            businesses.Add(new Business { Category = "Restaurant", Name = "Pizza Frank" });
            businesses.Add(new Business { Category = "Winkel", Name = "Okay Gent" });
            businesses.Add(new Business { Category = "Cafe", Name = "Cafe bob" });
            filteredBusinesses = businesses;
            this.InitializeComponent();
        }


        public void Home_ItemClick(object sender, ItemClickEventArgs args)
        {

        }

        private void GekozenBusiness_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get instance of Combobox
            ComboBox cb = sender as ComboBox;

            // Get selected item of Combobox
            string selectedItem = (String)cbCategorie.SelectedItem;
            
            // use filter method
            filterBusiness(selectedItem,businesses.ToList());
        }

        public IEnumerable<Business> filterBusiness(string categorie, List<Business> bisList)
        {
            filteredBusinesses.Clear();
            var b = new List<Business>();
            
            b = bisList.Where(o => o.Category == categorie).ToList();

            if (categorie == "geen categorie")
            {
                return businesses;
            }
            else
            {
                if (b.Count() > 0)
                {
                    b.ForEach(bus => filteredBusinesses.Add(bus));
                }
            }

            return filteredBusinesses;
        }
    }
}
