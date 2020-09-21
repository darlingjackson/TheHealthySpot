using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHealthySpot.Data.Entites
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product product { get; set; } // relationships through foren keys one to one
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}
