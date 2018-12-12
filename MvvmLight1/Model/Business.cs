using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class Business
    {
        public Guid BusinessId { get; set; }
        public string Name { get; set; }
        public String Category { get; set; }

        [ForeignKey("Business")]
        public User User {get;set;}
    }
}
