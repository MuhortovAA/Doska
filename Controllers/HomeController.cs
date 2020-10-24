using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Models;
using Microsoft.AspNetCore.Mvc;

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
            //var result = repository.Catalogs.GroupBy(c => c.NameTitle, c => c.NameSubtitle, (key, g) => new { title = key, subtitles = g.ToList() });
            return View(repository.Catalogs);
        }
        //public IActionResult CreatedAd(string id)
        //{

        //    return View("CreatedAd", id);
        //}
        public IActionResult SelectAds()
        {
            return View(repository.Catalogs);
        }
        public IActionResult AddAds(int id)
        {
            AdsModel adsModel = new AdsModel { IdCatalog = id, IdCustomer = 1, catalog=repository.GetCatalog(id) };
            AdsCreateModel adsCreate = mapper.Map<AdsCreateModel>(adsModel);
            return View(adsCreate);
        }
        [HttpPost]
        public RedirectToActionResult AddAds(AdsCreateModel adsCreate)
        {
            Ads ads = mapper.Map<Ads>(adsCreate);
            //var result = new Ads { AdsCreate = ads.AdsCreate, AdsText = ads.AdsText, IdCatalog = ads.IdCatalog, IdCustomer = ads.IdCustomer };
            repository.CreateAds(ads);

            return RedirectToAction(nameof(ViewAds));
        }

        public IActionResult ViewAds()
        {
            return View();
        }
    }
}
