using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
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
        private object eventCategoryId;
        private object eventCategoryID;
        private object await_context;

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

        //EventTypes
        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        //EventTypes Filter
        [HttpGet("[action]")]
        public async Task<IActionResult> FilteredTypes(
            int? eventTypeId,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 5)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (eventTypeId.HasValue)
            {
                query = query.Where(t => t.TypeId == eventTypeId);
            }
            var types = await query
                    .OrderBy(t => t.EventName)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            return Ok(types);

        }

        //Sort and filter Event by Category 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var events = await _context.EventItems.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> FilteredCategories(int? eventCategoryId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)

        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (eventCategoryId.HasValue)

            {
                query = query.Where(c => c.CatagoryId == eventCategoryId);
            }


            var events = await _context.EventItems

                    .OrderBy(c => c.EventCategory)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return Ok(events);
        }

        //Get ADressess
        [HttpGet("[action]")]
        public async Task<IActionResult> Addresses()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return Ok(addresses);
        }

        //Address Filter
        [HttpGet("[action]/Filtered/{addressid}")]
        public async Task<IActionResult> Addresses(
            int? addressid,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 5)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (addressid.HasValue)
            {
                query = query.Where(t => t.AddressId == addressid);
            }
            var events = await query
                    .OrderBy(t => t)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            return Ok(events);

        }
    }
    
}

            

        

    