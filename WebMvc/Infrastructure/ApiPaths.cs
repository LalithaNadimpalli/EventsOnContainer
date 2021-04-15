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
            public static string GetAllEventItems(string baseUri, int page, int take, int? category, int? type)
            {
                var filterQs = string.Empty;
                
                    if (category != 0 && type == 0)
                    {
                        var categoryQs = category.Value.ToString();
                        filterQs = $"EventCategories/{categoryQs}";
                        return $"{baseUri}{filterQs}?pageIndex={page}&pageSize={take}";
                    }
                    if (type != 0 && category == 0)
                    {
                        var typeQs = type.Value.ToString();
                        filterQs = $"EventTypes/{typeQs}";
                        return $"{baseUri}{filterQs}?pageIndex={page}&pageSize={take}";
                    }

                    if (category == 0 && type == 0)
                    {
                        filterQs = string.Empty;
                        return $"{baseUri}Items{filterQs}?pageIndex={page}&pageSize={take}";
                }

                    if (category.HasValue && type.HasValue)
                    {
                        var categoryQs = category.Value.ToString();
                        var typeQs = type.Value.ToString();
                        // filterQs = $"?Catagory={catagoryQs}&Type&{typeQs}";
                        filterQs = $"/Category/{categoryQs}/Type/{typeQs}";
                    }

                    
                               
                Debug.WriteLine($"{baseUri}Items{filterQs}?pageIndex={page}&pageSize={take}");
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
