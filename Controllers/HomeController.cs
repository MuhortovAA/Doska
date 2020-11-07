using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Doska.Controllers
{
    public class HomeController : Controller
    {
        private IvCatalogRepository repository;
        private IMapper mapper;
        public HomeController(IvCatalogRepository repo, IMapper _mapper)
        {
            repository = repo;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View(repository.Catalogs);
        }
        [Authorize]
        public IActionResult CreateAds()
        {
            return View(repository.Catalogs);
        }
        [Authorize]

        public IActionResult AddAds(int id)
        {
            AdsModel adsModel = new AdsModel { IdCatalog = id, IdCustomer = 1, catalog = repository.GetCatalog(id) };
            AdsCreateModel adsCreate = mapper.Map<AdsCreateModel>(adsModel);
            return View(adsCreate);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddAds(AdsCreateModel adsCreate)
        {
            Ads ads = mapper.Map<Ads>(adsCreate);
            if (ModelState.IsValid)
            {
                repository.CreateAds(ads);
                TempData["message"] = $"Ads number:{ads.IdCatalog} has been created.";
                return RedirectToAction(nameof(ViewCustomerAds), new { id = ads.IdCustomer });
            }
            else
            {
                return View(adsCreate);
            }

        }

        [Authorize]

        public IActionResult ViewCustomerAds(int id)
        {
            List<Ads> result = repository.GetCustomerAdses(id);
            return View(result);
        }
        public IActionResult ViewSelectAds(int id)
        {
            List<Ads> result = repository.GetAdses(id);

            return View(result);
        }
    }
}
