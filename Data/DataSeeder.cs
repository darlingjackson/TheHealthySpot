using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheHealthySpot.Data.Entites;

namespace TheHealthySpot.Data
{
    public class DataSeeder
    {
        //helps you seed the database that it allows you to read data from the Healthy Context
        private readonly HealthyContext _ctx;
        private readonly IWebHostEnvironment _hosting;
         public DataSeeder(HealthyContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }
        
        public void Seed()
        {
            //Check with the database to make sure it excist
            _ctx.Database.EnsureCreated();

            //check that the context exist
            if (!_ctx.Products.Any())//"return true if there are any in the databsei"
            {
                //Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/Food.json"); //maping to the location and json
                var json = File.ReadAllText(filepath); //telling it to read all the text in the file looked in the path stated above
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);// deserializeobject and seriolize into the type that you want.  
                _ctx.Products.AddRange(products);

                //adding an order to show inigration of both seedding styles
                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                            {
                              product = products.First(),
                              Quantity = 5,
                              UnitPrice = products.First().Price
                            }
                    };
                }

                //make sure the it saves
                _ctx.SaveChanges();

            }
        }
    }
}
