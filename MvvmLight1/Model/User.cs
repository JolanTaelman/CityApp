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

        public Business Business { get; set; }
    }
}
