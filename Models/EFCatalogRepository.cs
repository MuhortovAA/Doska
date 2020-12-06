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
        public List<AdsCustomer> GetCustomerAdses2(string Id)
        {
            var IdCustomerParam = new SqlParameter("@IdCustomer", Id);
            var result = context.AdsesCust.FromSqlRaw("exec [dbo].[sp_CustomerAdses2] @IdCustomer", IdCustomerParam).ToList();
            return result;
        }
        public List<Ads> GetAdses(int Id)
        {
            var IdCatalogParam = new SqlParameter("@IdCatalog", Id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_SelectAdses] @IdCatalog", IdCatalogParam).ToList();

            return result;
        }
        public List<AdsSelect> GetAdses2(int Id)
        {
            var IdCatalogParam = new SqlParameter("@IdCatalog", Id);
            var result = context.AdsesSel.FromSqlRaw("exec [dbo].[sp_SelectAdses2] @IdCatalog", IdCatalogParam).ToList();

            return result;
        }
        public List<Ads> GetAdses(string findtext)
        {
            var findtextParam = new SqlParameter("@find", findtext);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_FindAdses] @find", findtextParam).ToList();

            return result;
        }
        public List<AdsFind> GetAdses2(string findtext)
        {
            var findtextParam = new SqlParameter("@find", findtext);
            var result = context.AdsesFind.FromSqlRaw("exec [dbo].[sp_FindAdses2] @find", findtextParam).ToList();

            return result;
        }
        public int GetCountAdses(int Id)
        {
            var IdCatalogParam = new SqlParameter("@IdCatalog", Id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_SelectAdses] @IdCatalog", IdCatalogParam).ToList().Count();

            //var count = context.Adses.FromSqlRaw("exec [dbo].[sp_CountAdses] @IdCatalog", IdCatalogParam).ToList().Count();
            //var result = Convert.ToInt32(count ?? "0");
            //return result;
            return result;
        }

        public Ads GetAds(string id)
        {
            var IdParam = new SqlParameter("@Id", id);
            var result = context.Adses.FromSqlRaw("exec [dbo].[sp_GetAds] @Id", IdParam).ToList().First();
            return result;
        }
        public void UpdateAds(Ads ads)
        {
            context.Adses.Update(ads);
        }

        public void DeleteAds(Ads ads)
        {
            context.Adses.Remove(ads);
            context.SaveChanges();

        }
    }
}
