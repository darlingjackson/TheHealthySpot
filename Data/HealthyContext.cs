using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHealthySpot.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace TheHealthySpot.Data
{
    public class HealthyContext: DbContext //DbContext is a class that knows how to execute quieries to a data stoe
    {
        //constructor that accepts the dbcontext option
        //when the context is being added it is taking the options specified in the startup and passing them into the context so that it know what connection sting to use 
        public HealthyContext(DbContextOptions<HealthyContext> options) : base(options)
        {
        }

        //property that allow us to access the different entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        //override the OnModelCreation so that you can dictaite the mapping 
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            //Manually entering a new order
            ModelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber= "12345"
                });

        }
    }
}
