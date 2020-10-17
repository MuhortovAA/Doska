using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class CatalogRepository : ICatalogRepository
    {
        public IEnumerable<Catalog> Catalogs { get; }
    }
}
