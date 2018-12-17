using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class Uren
    {
        public Guid UrenId { get; set; }
        public DateTime Openingsuren { get; set; }
        public DateTime Sluitingsuren { get; set; }
        public string Dag { get; set; }
    }
}
