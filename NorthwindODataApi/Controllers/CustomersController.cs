using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using NorthwindAccess.Models;

namespace NorthwindODataApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ODataController
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly NorthwindDbContext _context;

        public CustomersController(ILogger<CustomersController> logger, NorthwindDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet, EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet, EnableQuery]
        [Route("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var item = await _context.Customers.SingleOrDefaultAsync(d => d.CustomerId == key);
            return Ok(item);
        }
    }
}
