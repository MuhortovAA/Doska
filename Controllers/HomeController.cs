using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doska.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doska.Controllers
{
    public class HomeController : Controller
    {
        private IvCatalogRepository repository;
        public HomeController(IvCatalogRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            //var result = repository.Catalogs.GroupBy(c => c.NameTitle, c => c.NameSubtitle, (key, g) => new { title = key, subtitles = g.ToList() });
            return View(repository.Catalogs);
        }
        public IActionResult CreatedAd(string id)
        {
            
            return View("CreatedAd", id);
        }
        public IActionResult CreateAds()
        {
            return View(repository.Catalogs);
        }
    }
}
