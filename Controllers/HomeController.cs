using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Models;
using Doska.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Doska.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private IvCatalogRepository repository;
        private IMapper mapper;
        private SignInManager<IdentityUser> signInManager;
        private readonly ILogger logger;

        public int PageSize = 7;

        public HomeController(IvCatalogRepository repo, IMapper _mapper, UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr,
            ILogger<HomeController> _logger)
        {
            userManager = userMgr;
            repository = repo;
            mapper = _mapper;
            logger = _logger;
            signInManager = signInMgr;

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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AdsModel adsModel = new AdsModel { IdCatalog = id, IdCustomer = userId, catalog = repository.GetCatalog(id) };
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
                logger.LogInformation($"Add ads's customer ID:{adsCreate.IdCustomer},  text: {adsCreate.AdsText}");
                return RedirectToAction(nameof(ViewCustomerAds), new { id = ads.IdCustomer });
            }
            else
            {
                return View(adsCreate);
            }

        }

        [Authorize]

        public IActionResult ViewCustomerAds(string id)
        {
            List<Ads> result = repository.GetCustomerAdses(id);
            return View(result);
        }
        [Authorize]
        public IActionResult ViewCustomerAdses()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<AdsCustomer> result = repository.GetCustomerAdses2(id);
            return View(result);
        }
        public IActionResult ViewSelectAds(int id)
        {
            List<Ads> result2 = repository.GetAdses(id);
            List<Ads> result = repository.GetAdses(id).Skip((1 - 1) * PageSize).Take(PageSize).ToList();


            return View(result);
        }
        [Route("[controller]/[action]/{contentid:int}/{pageid:int?}")]
        public IActionResult ViewSelectAds(string contentid = "1", string pageid = "1")
        {
            int id = Convert.ToInt32(contentid ?? "1");
            int PageNumber = Convert.ToInt32(pageid ?? "1");
            int count = repository.GetCountAdses(id);
            TempData["message"] = $"Найдено {count} объявлений.";
            logger.LogInformation($"[{nameof(ViewSelectAds)}] Выполнен поиск по contentid: {contentid}, pageid: {pageid}, найдено: {count}");

            AdsesListViewModel result = new AdsesListViewModel
            {
                Catalog = repository.Catalogs.Where(c => c.id == id).First(),
                //Adses = repository.GetAdses(id).OrderByDescending(a => a.AdsCreate).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList(),
                Adses = repository.GetAdses2(id).OrderByDescending(a => a.AdsCreate).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo { CurrentPage = PageNumber, ItemPerPage = PageSize, TotalItems = count }
            };
            return View(result);
        }


        public IActionResult FindAdses() => View();

        [HttpPost]
        public IActionResult FindAdses(string findtext)
        {
            if (ModelState.IsValid)
            {
                logger.LogInformation($"[{nameof(FindAdses)}] Выполнен RedirectToAction: {nameof(ViewFindAdses)} слово для поиска:{findtext}");
                return RedirectToAction(nameof(ViewFindAdses), new { find = findtext });
            }
            else
            {

                string mes = $"Ошибка поиска по слову: {findtext}";
                TempData["message"] = mes;
                logger.LogInformation($"[{nameof(FindAdses)}] {mes}");
                return View();
            }

        }
        public IActionResult ViewFindAdses(string find)
        {

            List<AdsFind> adses = repository.GetAdses2(find);
            TempData["message"] = $"Найдено {adses.Count()} объявлений.";
            logger.LogInformation($"[{nameof(ViewFindAdses)}] Выполнен поиск по слову: {find}, найдено: {adses.Count()}");
            return View(adses);
        }
    }
}
