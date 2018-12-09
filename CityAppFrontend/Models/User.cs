using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class User
    {
        public User(Guid userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
    
    }
}
