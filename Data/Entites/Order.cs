using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHealthySpot.Data.Entites
{
    public class Order
    {
        public int Id { get; set; } //auto incremented 
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; } //relate one entety to another entity (one to many relationship)
    }
}
