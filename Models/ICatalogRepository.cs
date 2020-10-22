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
    }
}
