using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RatersOfTheLostBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            UpdateDatabase(host.Services);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    private static void UpdateDatabase(IServiceProvider services)
    {
        using (var serviceScope = services.CreateScope())
        {
            using (var db = serviceScope.ServiceProvider.GetService<BusinessDbContext>())
            {
                db.Database.Migrate();
            }
        }
    }
    }
}
