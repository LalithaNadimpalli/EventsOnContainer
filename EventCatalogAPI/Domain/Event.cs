using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string EventImageUrl { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string HostDescription { get; set; }



        public string Location { get; set; }
        public string Address { get; set; }

        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public EventCategory EventCategory { get; set; }
        public EventType EventType { get; set; }



    }
}
