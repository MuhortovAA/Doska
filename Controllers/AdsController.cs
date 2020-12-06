using AutoMapper;
using Doska.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Controllers
{
    [Authorize]
    public class AdsController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private IvCatalogRepository repository;
        private IMapper mapper;
        private SignInManager<IdentityUser> signInManager;
        private readonly ILogger logger;
        public AdsController(IvCatalogRepository repo, IMapper _mapper, UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, ILogger<HomeController> _logger)
        {
            userManager = userMgr;
            repository = repo;
            mapper = _mapper;
            logger = _logger;
            signInManager = signInMgr;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var ads = repository.GetAds(id);
            return View(ads);
        }
        [HttpPost]
        public IActionResult Edit(Ads ads)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAds(ads);
                TempData["message"] = $"Обьявление обновлено";
                logger.LogInformation($"Обьявление обновлено. id:{ads.Id}  text: {ads.AdsText}");
                //return RedirectToAction("ViewCustomerAdses", "Home", new { id = ads.IdCustomer });
                return RedirectToAction("ViewCustomerAdses", "Home");

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var ads = repository.GetAds(id);
            return View(ads);
        }
        [HttpPost]
        public IActionResult Delete(Ads ads)
        {
            repository.DeleteAds(ads);
            TempData["message"] = $"Обьявление удалено";
            logger.LogInformation($"Обьявление удалено. id:{ads.Id}  text: {ads.AdsText}");


            return RedirectToAction("ViewCustomerAdses", "Home");

        }



        [HttpGet]
        public IActionResult Details(string id)
        {
            var ads = repository.GetAds(id);
            return View(ads);
        }
    }
}
