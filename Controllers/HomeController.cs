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
            var result = repository.Catalogs;
            return View(repository.Catalogs);
        }
        public IActionResult CreatedAd(string id)
        {
            var result = id;
            return View();
        }
    }
}
