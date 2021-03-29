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
        
        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory { Category = "Music" },
                new EventCategory { Category = "Sports" },
                new EventCategory { Category = "Food and Drink" },
                new EventCategory { Category = "Book Club" },
                new EventCategory { Category = "Kids Festival" },
                new EventCategory { Category = "Business" },
                new EventCategory { Category = "Job Fair" },
                new EventCategory { Category = "Movies" },
                new EventCategory { Category = "Tech" },
                new EventCategory { Category = "Car Show" },
                new EventCategory { Category = "Other" }

            };
        }
        
        private static IEnumerable<EventItem> GetEventItem()
            {
                return new List<EventItem>()
                {
                    new EventItem { EventTypeId = 2, EventName = "FireWrok ",
                        EventCatagoryId = 11, Description = "Fouth of July celebration ", Price = 22.45M,
                        EventStartTime =  11:30pm , EventEndTime = 12:30 ,
                        Organizer = "Adam Silver " , AddressId = 2, EventImageId = "http://externaleventbaseurltoberplaced/api/pic1"},
                    new EventItem { EventTypeId = 2, EventName = "Pumpkin Decorating For Dammy ",
                        EventCatagoryId =5 , Description = "Cool way to decorate pumpkin for Halloween ", Price = 10.00M,
                        EventStartTime = 9:00am , EventEndTime = 5:00pm,
                        Organizer = "Marta Stewart " , AddressId = 5, EventImageId = "http://externaleventbaseurltoberplaced/api/pic2"},
                    new EventItem { EventTypeId = 2, EventName = "Memorial Day ",
                        EventCatagoryId = 11, Description = "Memorial Day Remembrance Walk" , Price = 0.00M,
                        EventStartTime = 8:00am, EventEndTime = 12:00pm,
                        Organizer = "Barack Obama ", AddressId = 1, EventImageId = "http://externaleventbaseurltoberplaced/api/pic3" },
                    new EventItem { EventTypeId = 3, EventName = "Seminar ",
                        EventCatagoryId = 6, Description = "How to gradute without student loan ", Price = 99.99M,
                        EventStartTime = 1:00pm , EventEndTime = 4:00pm,
                        Organizer = "Dr. Ben Jackson " , AddressId = 4, EventImageId = "http://externaleventbaseurltoberplaced/api/pic4"},
                    new EventItem { EventTypeId = 2, EventName = "Music Concert ",
                        EventCatagoryId = 1, Description = "Best 80's Party ever ", Price = 125.00M,
                        EventStartTime = 9:00pm, EventEndTime = 1:00am,
                        Organizer = "Linda Campbell ", AddressId = 1, EventImageId = "http://externaleventbaseurltoberplaced/api/pic5"},
                    new EventItem { EventTypeId = 2, EventName = "Botany",
                        EventCatagoryId = 11, Description = "World Congress on Medical and Aromatic Plants", Price =  63.45M,
                        EventStartTime = 10:00am, EventEndTime = 6:00pm,
                        Organizer = "Sarah Clark ", AddressId = 3, EventImageId = "http://externaleventbaseurltoberplaced/api/pic6" },
                    new EventItem { EventTypeId = 3, EventName = "Hindu's festival in Seattle",
                        EventCatagoryId = 11, Description = "Come join us to celebrate life ", Price = 0.00M ,
                        EventStartTime = 10:00am, EventEndTime = 6:00pm,
                        Organizer = "Rita Pia " , AddressId = 7, EventImageId = "http://externaleventbaseurltoberplaced/api/pic7"},
                    new EventItem { EventTypeId = 2, EventName = "Celebrity birthday cake Studio",
                        EventCatagoryId =5 , Description = "Beautifully delicious cakes for birthday", Price = 345.00M,
                        EventStartTime = 8:00am, EventEndTime = 8:00pm,
                        Organizer = "Sue Jeff ", AddressId = 8, EventImageId = "http://externaleventbaseurltoberplaced/api/pic8"},
                    new EventItem { EventTypeId = 2, EventName = "Wine Tasting",
                        EventCatagoryId = 3, Description = "The best Wine in Washington state ", Price = 24.95M,
                        EventStartTime = 1:00pm, EventEndTime = 9:00pm,
                        Organizer = "Tad Robert ", AddressId = 4, EventImageId = "http://externaleventbaseurltoberplaced/api/pic9" }
                };
            }
        
    }
}

            
            
        
    

   

   

