using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class Business
    {
        public Business(int businessId, string name, string category)
        {
            BusinessId = businessId;
            this.name = name;
            this.category = category;
        }

        public int BusinessId { get; set;}
        public string name { get; set; }
        public String category { get; set; }
    }
}
