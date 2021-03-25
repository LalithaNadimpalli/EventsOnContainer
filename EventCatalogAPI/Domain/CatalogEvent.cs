using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public decimal Fee { get; set; }
        public string EventImageUrl { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }

        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public CatalogCategory CatalogCategory { get; set; }
        public CatalogType CatalogType { get; set; }



    }
}
