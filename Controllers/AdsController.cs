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



        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var ads = repository.GetAds(id);
            return View(ads);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Ads ads)
        {
            //if (ModelState.IsValid)
            //{
            //    repository.CreateAds(ads);
            //    TempData["message"] = $"Ads number:{ads.IdCatalog} has been created.";
            //    logger.LogInformation($"Add ads's customer ID:{adsCreate.IdCustomer},  text: {adsCreate.AdsText}");
            //    return RedirectToAction(nameof(ViewCustomerAds), new { id = ads.IdCustomer });
            //}
            //else
            //{
            //    return View(adsCreate);
            //}
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            return View();
        }
    }
}
