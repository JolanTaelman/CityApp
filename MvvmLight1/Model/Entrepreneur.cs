using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class Entrepreneur : User
    {
        public Guid BusinessId { get; set; }
        

        public Entrepreneur(Guid userId, string name) : base(userId, name)
        {
        }
     }
}
