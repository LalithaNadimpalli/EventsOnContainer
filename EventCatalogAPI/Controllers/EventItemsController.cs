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
    public class EventItemsController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventItemsController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //Re-orders events by date - oldest to newest
        [HttpGet("action")]
        public async Task<IActionResult> Dates()
        {
            var events = await _context.EventItems
                .OrderBy(d => d.EventStartTime)
                .ToListAsync();

            return Ok(events);
        }

        //Sorts event by month
        [HttpGet("action")]
        public async Task<IActionResult> FilterByMonth(
            [FromQuery] string month)
        {
            var events = await _context.EventItems
                .Where(d => d.EventStartTime.ToString("MMMM") == month)
                .OrderBy(d => d.EventStartTime)
                .ToListAsync();

            return Ok(events);
        }

        //filters events by specific date
        [HttpGet("action")]
        public async Task<IActionResult> FilterByDate(
            [FromQuery] string month,
            [FromQuery] int day,
            [FromQuery] int year)
        {
            var events = await _context.EventItems
                .Where(d => d.EventStartTime.ToString("MMMM") == month)
                .Where(d => d.EventStartTime.Day == day)
                .Where(d => d.EventStartTime.Year == year)
                .OrderBy(d => d.EventStartTime)
                .ToListAsync();

            return Ok(events);
        }

    }
}
