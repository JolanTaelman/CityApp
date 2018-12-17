using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.ViewModel
{
    class RegistreerBusinessViewModel
    {
        public List<string> Categorieën { get; set; }
        public List<string> Uren { get; set; }
        public List<string> Minuten { get; set; }

        
        public RegistreerBusinessViewModel()
        {
            Categorieën = new List<string>
            {
                "Pizza",
                "Chinees",
                "Frieten",
                "Pita"
            };

            Uren = new List<string>
            {
                "00",
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20",
                "21",
                "22",
                "23"
            };

            Minuten = new List<string>
            {
                "00",
                "15",
                "30",
                "45"
            };
        }
    }
}
