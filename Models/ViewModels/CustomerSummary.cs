using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Doska.Models.ViewModels
{
    public class CustomerSummary : ViewComponent
    {
        IvCatalogRepository repository;
        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;
        public CustomerSummary(IvCatalogRepository repo, SignInManager<IdentityUser> signInMgr, UserManager<IdentityUser> userMgr)
        {
            repository = repo;
            signInManager = signInMgr;
            userManager = userMgr;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            string id = userManager.GetUserId(signInManager.Context.User);


            List<Ads> result = repository.GetCustomerAdses(id);
            return View(new CustomerSummaryViewModel { CountAdses = result.Count() });
        }
    }
}
