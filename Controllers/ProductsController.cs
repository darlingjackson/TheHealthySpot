using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheHealthySpot.Data;
using TheHealthySpot.Data.Entites;

namespace TheHealthySpot.Controllers
{
    //expose data to the api


    [Route("api/[controller]")]
    [ApiController]//tell the tools what controllers are api controllers
    [Produces("application/json")] //tell it that this api controller will always retun json
    public class ProductsController: ControllerBase
    {
        private readonly IHealthyRepository _repository;
        private readonly ILogger _logger;
        public ProductsController(IHealthyRepository repository, ILogger<Product> logger) 
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get() 
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Products: {ex}");
                return BadRequest();
            }
        }
    }
}
