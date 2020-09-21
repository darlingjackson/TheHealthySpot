using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheHealthySpot.Data;
using TheHealthySpot.Services;


namespace TheHealthySpot
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) //allows us to inject basic basic interfaces that are stored in the program.cs 
        {
            _config = config;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HealthyContext>(cfg => 
            {
                cfg.UseSqlServer(_config.GetConnectionString("HealthyConnectionString")); //pass in the connection sting to tell it what database to use
            });

            services.AddTransient<DataSeeder>();

            services.AddScoped<IHealthyRepository, HealthyRepository>();


            //add the meilservices
            services.AddTransient<IMailServices, NullMailServices>();
            //Add Suppost real mail service


            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //This makes it so that this page only shows up in debug mode
            {
                app.UseDeveloperExceptionPage(); //an exception page shown for developers
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //Turn on MVC
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                      "{controller}/{action}/{id?}",
                      new { controller = "App", Action = "Index" });
            });

            //app.UseDefaultFiles();//(serves .html files) by default displays index page
            app.UseStaticFiles(); //Serves files that live in the wwwroot directory

        }
    }
}
