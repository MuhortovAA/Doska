﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class EFCatalogRepository : IvCatalogRepository
    {
        private ApplicationDbContext context;
        public EFCatalogRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<vCatalog> Catalogs => context.vCatalog;

        public void CreateAds(Ads ads)
        {
            context.Adses.Add(ads);
            context.SaveChanges();
        }

        public vCatalog GetCatalog(int id) => context.vCatalog.First(c => c.id == id);
        public List<Ads> GetCustomerAdses(int Id)
        {
            var IdCustomerParam = new SqlParameter("@IdCustomer", Id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_CustomerAdses] @IdCustomer", IdCustomerParam).ToList();
            return result;
        }

    }
}
