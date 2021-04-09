using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;

        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoryAsync()
        {
            var brandUri = ApiPaths.Catalog.GetAllBrands(_baseUrl);
            var dataString = await _client.GetStringAsync(brandUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var brands = JArray.Parse(dataString);
            foreach (var brand in brands)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = brand.Value<string>("id"),
                        Text = brand.Value<string>("brand")
                    });
            }
            return items;
        }

        public async Task<Catalog> GetEventItemsAsync(int page, int size, int? category, int? type)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_baseUrl, page, size, category, type);
            var dataString = await _client.GetStringAsync(catalogItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetEventTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    });
            }
            return items;
        }
    }
}
