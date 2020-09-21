using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheHealthySpot.Data;

namespace TheHealthySpot.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IHealthyRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IHealthyRepository repository, ILogger<OrdersController> logger) 
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
           
        }
    }
}
