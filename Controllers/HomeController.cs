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
        private ICatalogRepository repository;
        public HomeController(ICatalogRepository repo)
        {
            repository = repo;
        }


        public IActionResult Index()
        {
            return View(repository.Catalogs);
        }
    }
}
