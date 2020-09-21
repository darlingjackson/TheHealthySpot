using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheHealthySpot.Data.Entites;

namespace TheHealthySpot.Data
{
    public interface IHealthyRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
    }
}