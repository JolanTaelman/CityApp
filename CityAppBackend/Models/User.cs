using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Staat { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public Business Business { get; set; }
    }
}
