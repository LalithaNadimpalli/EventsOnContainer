using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>()
            {
                new EventType() { Type= "Conference"},
                new EventType() { Type= "VirtualEvent"},
                new EventType() { Type= "SocialEvent"},
                new EventType() { Type= "CorporateEvent"},
                new EventType() { Type= "Party"},
                new EventType() { Type= "CommunityEvent"},

            };
        }

    }
}
