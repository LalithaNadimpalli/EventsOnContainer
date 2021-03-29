using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EventCatalogAPI.Data
{
    public class EventSeed
    {
        public static void Seed(EventContext eventContext)
        {
            //eventContext.Database.Migrate();
            //we are checking whether the database is created or not in the below line.
            //catalogContext.Database.EnsureCreated();
            //Below Line checks the database, if it has any rows
            if (!eventContext.Addresses.Any()) //EventAddress Table
            {
                eventContext.Addresses.AddRange(GetAddress());
                //Until We save changes, it will not commit or create table.
                eventContext.SaveChanges();
            }
            if (eventContext.EventTypes.Any()) //EventTypes Table
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (eventContext.EventCategories.Any()) //EventCategories Table
            {
                eventContext.EventCategories.AddRange(GetEventCategories());
                eventContext.SaveChanges();
            }
            if (eventContext.EventItems.Any()) //EVentItems Table
            {
                eventContext.EventItems.AddRange(GetEventItems());
                eventContext.SaveChanges();
            }
        }
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>()
            {
                new EventType() { Type= "Online"},
                new EventType() { Type= "Inperson"},
                new EventType() { Type= "Online&Inperson"},
             
            };
        }
        private static IEnumerable<EventCategory> GetEventCategories()
        {
            throw new NotImplementedException();
        }
        private static IEnumerable<EventItem> GetEventItems()
        {
            throw new NotImplementedException();
        }
        private static IEnumerable<EventAddress> GetAddress()
        {
            return new List<EventAddress>
            {
                new EventAddress
                {
                    City = " Woodinville", State = "WA ", ZipCode =98055  , StreetAddress = " 12345 SE 100th Eve"
                },
                new EventAddress
                {
                    City = " Redmond", State = "WA ", ZipCode =98011  , StreetAddress = " 12463 NE 109th Eve"
                },
                new EventAddress
                {
                    City = " Bellevue", State = "WA ", ZipCode =98076  , StreetAddress = " 12100 SE 201st way"
                },
                new EventAddress
                {
                    City = " Seattle", State = "WA ", ZipCode =98030  , StreetAddress = " 12302 SE 108th Eve"
                },
                new EventAddress
                {
                    City = " Renton", State = "WA ", ZipCode =98044  , StreetAddress = " 12903 SE 202nd way"
                },
                new EventAddress
                {
                    City = " Bellevue", State = "WA ", ZipCode =98046  , StreetAddress = " 12908 NE 102nd way"
                },
                new EventAddress
                {
                    City = " Sammamish", State = "WA ", ZipCode =98350  , StreetAddress = " 12803 SE 113th St"
                },
                new EventAddress
                {
                    City = " Seattle", State = "WA ", ZipCode =98121  , StreetAddress = " 12460 NE 106th way"
                }
            };
        }
    }
}

            
            
        
    

   

   

