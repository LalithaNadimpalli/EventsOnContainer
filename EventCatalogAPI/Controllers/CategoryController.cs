using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public CategoryController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)
        {
            var events = await _context.EventItems
                    .OrderBy(c => c.EventCategory)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return Ok(events);
        }

        
    }

   
}
