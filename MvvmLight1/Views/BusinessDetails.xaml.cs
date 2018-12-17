using MvvmLight1.Model;
using System;
using System.Collections.Generic;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MvvmLight1.Views
{
    public sealed partial class BusinessDetails : UserControl
    {
        public Business gekozenBusiness;

        public BusinessDetails()
        {
            var openingsuren = new List<Uren>();
            openingsuren.Add(new Uren { Dag = "Maandag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Dinsdag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Woensdag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Donderdag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Vrijdag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Zaterdag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });
            openingsuren.Add(new Uren { Dag = "Zondag", Openingsuren = DateTime.Now, Sluitingsuren = DateTime.Now });

            this.gekozenBusiness = new Business { Name = "Business 1", Category = "Restaurant", OpeningsUren =  openingsuren};
            this.InitializeComponent();
        }
    }
}
