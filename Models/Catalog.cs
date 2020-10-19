using Doska.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    //[Keyless]
    public class Catalog
    {
        //public int id { get; set; }
        public string Title { get; set; }
        public IEnumerable<SubtitleJson> Subtitles { get; set; }
    }
    public class SubtitleJson
    {
        public string NameSubtitle { get; set; }
    }
    public class Subtitle
    {
        public int id { get; set; }
        public string NameSubtitle { get; set; }
        public int idTitle { get; set; }
    }
    public class Title
    {
        public int id { get; set; }
        public string NameTitle { get; set; }
    }
    public class vCatalog
    {
        public int id { get; set; }
        public string NameTitle { get; set; }
        public string NameSubtitle { get; set; }
        public int TitleId { get; set; }
    }
    public class DataDoska
    {
        public IEnumerable<Catalog> repository;
        public DataDoska(JsonFileCatalogService service)
        {
            repository = new CatalogJsonRepository(service).Catalogs;
        }
        public IEnumerable<Catalog> GetCatalogs()
        {
            return repository;
        }
        public Title[] GetTitles()
        {
            var result = repository.GroupBy(
                c => c.Title,
                c => c.Subtitles,
                (key, g) => new Title { NameTitle = key}).ToArray<Title>();
            return result;
        }
    }
}
