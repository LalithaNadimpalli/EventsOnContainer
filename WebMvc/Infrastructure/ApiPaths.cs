using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return  $"{baseUri}EventTypes";
            }
            public static string GetAllCatagorys(string baseUri)
            {
                return $"{baseUri}EventCategories";
            }
            public static string GetAllEventItems(string baseUri, int page, int take, int? catagory, int? type)
            {
                var filterQs = string.Empty;
                if (catagory.HasValue || type.HasValue)
                {
                    var catagoryQs = (catagory.HasValue) ? catagory.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/Catagory/{catagoryQs}/Type/{typeQs}";
                }
             
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

           
        }
    }
}

