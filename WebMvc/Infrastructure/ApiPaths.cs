using System;
using System.Collections.Generic;
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
            public static string GetAllEventItems(string baseUri, int page, int take, int? category, int? type)
            {
                var filterQs = string.Empty;
                if (category.HasValue || type.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                   // filterQs = $"?Catagory={catagoryQs}&Type&{typeQs}";
                     filterQs = $"/Category/{categoryQs}/Type/{typeQs}";


                    //  if we try using  Query  
                    // filterQs = $"?Catagory={catagoryQs}&Type={typeQs}";

                }
               // return "http://localhost:7810/api/EventItems/Item?pageIndex=0&pageSize=10";
                  return $"{baseUri}Items{filterQs}?pageIndex={page}&pageSize={take}";
            }



            //public static string GetAllEventItems(string baseUri, int page, int take, int? brand, int? type)
            //{
            //    var filterQs = string.Empty;
            //    if (brand.HasValue || type.HasValue)
            //    {
            //        var brandQs = (brand.HasValue) ? brand.Value.ToString() : "null";
            //        var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
            //        filterQs = $"/type/{typeQs}/brand/{brandQs}";
            //    }
            //    return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            //}
        }
    }
}
