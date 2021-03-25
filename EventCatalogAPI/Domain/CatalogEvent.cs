﻿using System;
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
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public decimal Price{ get; set; }
        public string EventImageUrl { get; set; }
        public float EventStartTime { get; set; }
        public float EventEndTime { get; set; }
        public int Duration { get; set; }
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public CatalogCategory CatalogCategory { get; set; }
        public CatalogType CatalogType { get; set; }


    }
}
