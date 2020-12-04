using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public interface ICatalogRepository
    {
        IEnumerable<Catalog> Catalogs { get; }
    }
    public interface IvCatalogRepository
    {
        IEnumerable<vCatalog> Catalogs { get; }
        vCatalog GetCatalog(int id);
        void CreateAds(Ads ads);
        List<Ads> GetCustomerAdses(string Id);
        List<AdsCustomer> GetCustomerAdses2(string Id);

        List<Ads> GetAdses(int Id);
        List<AdsSelect> GetAdses2(int Id);
        int GetCountAdses(int Id);
        List<AdsFind> GetAdses2(string findtext);
        Ads GetAds(string id);


    }
}
