using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class Entrepreneur : User
    {
        public string BusinessId { get; set; }
        

        public Entrepreneur(int userId, string name) : base(userId, name)
        {
        }


    }
}
