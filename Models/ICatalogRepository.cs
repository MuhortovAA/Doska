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
        List<Ads> GetAdses(int Id);
        List<Ads> GetAdses(string findtext);

    }
}
