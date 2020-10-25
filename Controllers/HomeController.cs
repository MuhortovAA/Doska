using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Models;
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
        public IActionResult SelectAds()
        {
            return View(repository.Catalogs);
        }
        public IActionResult AddAds(int id)
        {
            AdsModel adsModel = new AdsModel { IdCatalog = id, IdCustomer = 1, catalog = repository.GetCatalog(id) };
            AdsCreateModel adsCreate = mapper.Map<AdsCreateModel>(adsModel);
            return View(adsCreate);
        }
        [HttpPost]
        public RedirectToActionResult AddAds(AdsCreateModel adsCreate)
        {
            Ads ads = mapper.Map<Ads>(adsCreate);
            repository.CreateAds(ads);

            return RedirectToAction(nameof(ViewAds), new { id = ads.IdCustomer });
        }

        public IActionResult ViewAds(int id)
        {
            List<Ads> result = repository.GetCustomerAdses(id);
            return View(result);
        }
    }
}
