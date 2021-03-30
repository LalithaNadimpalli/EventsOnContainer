using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly EventContext _context;
        public DateController(EventContext context)
        {
            _context = context;
        }
        [HttpGet("action")]
        public async Task<IActionResult> Dates()
        {
            var events = await _context.EventItems
                .OrderBy(d => d.EventStartTime)
                .ToListAsync();

            return Ok(events);
        }
        [HttpGet("action")]
        public async Task<IActionResult> FilterByMonth(
            [FromQuery]string month)
        {
            var events = await _context.EventItems
                .Where(d => d.EventStartTime.ToString("MMMM") == month)
                .OrderBy(d => d.EventStartTime)
                .ToListAsync();

            return Ok(events);
        }
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
