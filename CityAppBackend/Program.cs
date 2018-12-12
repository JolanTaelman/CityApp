using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CityAppBackend.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityAppBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
           /* var dbcob = new DbContextOptionsBuilder<CityAppBackendContext>();
            dbcob.UseSqlServer("Data Source=DESKTOP-DBSBTJJ;Initial Catalog=CityApp;Integrated Security=True;Pooling=False");
                
            using (var db = new CityAppBackendContext(dbcob.Options))
            {

            }*/

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
