using Microsoft.Data.SqlClient;
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
        public List<Ads> GetCustomerAdses(string Id)
        {
            var IdCustomerParam = new SqlParameter("@IdCustomer", Id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_CustomerAdses] @IdCustomer", IdCustomerParam).ToList();
            return result;
        }

        public List<Ads> GetAdses(int Id)
        {
            var IdCatalogParam = new SqlParameter("@IdCatalog", Id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_SelectAdses] @IdCatalog", IdCatalogParam).ToList();

            return result;
        }

        public List<Ads> GetAdses(string findtext)
        {
            var findtextParam = new SqlParameter("@find", findtext);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_FindAdses] @find", findtextParam).ToList();

            return result;
        }
    }
}
