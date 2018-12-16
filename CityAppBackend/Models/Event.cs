using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityAppBackend.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        [ForeignKey("Business")]
        private Business Business { get; set; }
        private string Description { get; set; }
        private string Title { get; set; }
        private DateTime Date { get; set; }        
    }
}
