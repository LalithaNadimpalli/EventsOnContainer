using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventSeed
    {
        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            {
                new EventOrganizer { Coordinator = "Sam", Title = "Mr." },
                new EventOrganizer { Coordinator = "Jamie", Title = "Ms." },
                new EventOrganizer { Coordinator = "Jason", Title = "Mr." },
                new EventOrganizer { Coordinator = "Matthew", Title = "Mr." },
                new EventOrganizer { Coordinator = "Christian", Title = "Mrs." },
                new EventOrganizer { Coordinator = "Sarah", Title = "Miss." },
                new EventOrganizer { Coordinator = "Celeste", Title = "Miss." },
                new EventOrganizer { Coordinator = "Joe", Title = "Mr." },
                new EventOrganizer { Coordinator = "Michelle", Title = "Mrs." }

            };
        }
    }
}
