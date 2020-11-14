using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models.ViewModels
{
    public class CustomerSummary : ViewComponent
    {
        IvCatalogRepository repository;
        public CustomerSummary(IvCatalogRepository repo)
        {
            repository = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (TempData["UserId"] != null)
            {
                string id = TempData["UserId"].ToString();
                //List<Ads> result = repository.GetCustomerAdses("3b4cf489-38a4-4999-9bbb-ef6a7ae7a439");
                List<Ads> result = repository.GetCustomerAdses(id);
                return View(new CustomerSummaryViewModel { CountAdses = result.Count() });
            }
            else
            {
                return View(new CustomerSummaryViewModel { CountAdses = 0 });
            }


        }
    }
}
