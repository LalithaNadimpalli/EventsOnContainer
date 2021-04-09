using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IEventService _service;
        public CatalogController(IEventService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page, int? brandFilterApplied, int? typesFilterApplied, /*int? adressFilterApplied*/)
        {
            var itemsOnPage = 10;

            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, brandFilterApplied, typesFilterApplied /*adressFilterApplied */);

            var vm = new CatalogIndexViewModel
            {
                CatalogItems = catalog.Data,
                Brands = await _service.GetCategoryAsync(),
                Types= await _service.GetEventTypesAsync(),
                //Address = await _service.GetEventAddressAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = catalog.PageSize,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count/itemsOnPage)
                },
                BrandFilterApplied = brandFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0,
                //AdressFilterApplied = adressFilterApllied ?? 0
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}