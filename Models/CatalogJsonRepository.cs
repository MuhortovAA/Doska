﻿using Doska.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class CatalogJsonRepository : ICatalogRepository
    {
        public IEnumerable<Catalog> Catalogs { get; }

        public IEnumerable<vCatalog> vCatalog => throw new NotImplementedException();

        public CatalogJsonRepository(JsonFileCatalogService catalogs)
        {
            Catalogs = catalogs.GetCatalogs();
        }
    }
}
