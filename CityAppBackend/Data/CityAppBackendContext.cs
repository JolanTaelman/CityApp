using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CityAppBackend.Models;

namespace CityAppBackend.Models
{
    public class CityAppBackendContext : DbContext
    {
        public CityAppBackendContext (DbContextOptions<CityAppBackendContext> options)
            : base(options)
        {
        }
    
        public DbSet<CityAppBackend.Models.Business> Business { get; set; }

        public DbSet<CityAppBackend.Models.User> User { get; set; }

        public DbSet<CityAppBackend.Models.Event> Event { get; set; }
    }
}
