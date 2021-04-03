 using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Dates()
        {
            var events = await _context.EventItems
                .OrderBy(d => d.EventStartTime.Date)
                .ToListAsync();
            events = ChangeImageUrl(events);

            return Ok(events);
        }

        //Sorts event by month
        [HttpGet]
        [Route("[action]/{month}")]
        public async Task<IActionResult> FilterByMonth(int? month)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (month.HasValue)
            {
                query = query.Where(e => e.EventStartTime.Month == month);
            }

            var events = await query
                .OrderBy(e => e.EventStartTime)
                .ToListAsync();
            events = ChangeImageUrl(events);

            return Ok(events);
        }

        //filters events by specific date
        [HttpGet]
        [Route("[action]/{day}-{month}-{year}")]
        public async Task<IActionResult> FilterByDate(int? day, int? month, int? year)
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (day.HasValue && month.HasValue && year.HasValue)
            {
                query = query.Where(e => e.EventStartTime.Day == day)
                             .Where(e => e.EventStartTime.Month == month)
                             .Where(e => e.EventStartTime.Year == year);
            }

            var events = await query
                .ToListAsync();
            events = ChangeImageUrl(events);

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
        [HttpGet("[action]/{eventTypeId}")]
        public async Task<IActionResult> EventTypes(
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
            types = ChangeImageUrl(types);

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
        [Route("[action]/{eventCategoryId}")]
        public async Task<IActionResult> EventCategories(int? eventCategoryId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)

        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if (eventCategoryId.HasValue)

            {
                query = query.Where(c => c.CatagoryId == eventCategoryId);
            }


            var events = await query

                    .OrderBy(c => c.EventCategory)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            events = ChangeImageUrl(events);

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
        [HttpGet("[action]/Filtered/{city}")]
        public async Task<IActionResult> Addresses(
            string city,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 4)

        {
            if (city != null && city.Length != 0)
            {
                var items = await _context.EventItems.Join(_context.Addresses.Where(x => x.City.Equals(city)), eventItem => eventItem.AddressId,
              address => address.Id, (eventItem, address) => new
              {

                  eventId = eventItem.Id,
                  address = eventItem.Address,
                  eventName = eventItem.EventName,
                  description = eventItem.Description,
                  price = eventItem.Price,
                  eventImage = eventItem.EventImageUrl.Replace("http://externaleventbaseurltoberplaced",
                    _config["ExternalCatalogBaseUrl"]),
                  startTime = eventItem.EventStartTime,
                  endTime = eventItem.EventEndTime,
                  typeId = eventItem.TypeId,
                  categoryId = eventItem.CatagoryId}).OrderBy(c => c.eventId)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize).ToListAsync();           
                    return Ok(items);                
            }
          

           
            return Ok();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
              [FromQuery] int pageIndex = 0,
              [FromQuery] int pageSize = 4)
        {
            var items = await _context.EventItems
                .OrderBy(e => e.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangeImageUrl(items);
            return Ok(items);
        }
        private List<EventItem> ChangeImageUrl(List<EventItem> items)
        {
            items.ForEach(item =>
               item.EventImageUrl = item.EventImageUrl.
               Replace("http://externaleventbaseurltoberplaced",
              _config["ExternalCatalogBaseUrl"]));
            return items;
        }

    }
}

            

        

    