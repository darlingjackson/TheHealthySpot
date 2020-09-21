using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheHealthySpot.Data;
using Microsoft.Extensions.DependencyInjection;

namespace TheHealthySpot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedDb(host);
            host.Run();
        }

        //add a method that tells it how to seed
        private static void SeedDb(IWebHost host)
        {
            //scope factory create a scope that is true for the life of the request 
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope()) //using makes sure that it is closed once the scope is done
            {
                //get seeder object
                var seeder = scope.ServiceProvider.GetService<DataSeeder>();
                seeder.Seed();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Removing the default configuration options
            builder.Sources.Clear();

            //tells it to use the jason file as configuration
            builder.AddJsonFile("appsettings.json", false, true)
                   .AddEnvironmentVariables();

        }
    }
}