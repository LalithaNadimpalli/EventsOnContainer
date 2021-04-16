using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Event

        {
            public static string GetAllTypes(string baseUri)
            {
                // "http//localhost:7810/api/EventItems/CatalogType"
                return $"{baseUri}EventTypes";
            }
            public static string GetAllCategories(string baseUri)
            {

                //   "http//localhost:7810/api/Event/EventCategories"
                return $"{baseUri}EventCategories";
            }

            //   "http//localhost:7810/api/Event/Addresses"
            public static string GetAllEventAddresses(string baseUri)
            {
                return $"{baseUri}Addresses";
            }
            //Take is like we are asking user, how many items they want
            //Integrating filters in single API
            public static string GetAllEventItems(string baseUri, int page, int take, int? catagory, int? type, int? address)
            {
                //   var filterQs = string.Empty;
                var catagoryQs = (catagory.HasValue) ? catagory.Value : -1;
                var typeQs = (type.HasValue) ? type.Value : -1;
                var addressQs = (address.HasValue) ? address.Value : -1;              
                var filterQs = $"/category/{catagoryQs}/type/{typeQs}/address/{addressQs}";          
                return $"{baseUri}Items{filterQs}?pageIndex={page}&pageSize={take}";
            }        
        }
    }
}
