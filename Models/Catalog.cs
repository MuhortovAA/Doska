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
            //var result = repository.GroupBy(
            //    c => c.Title,
            //    c => c.Subtitles,
            //    (key, g) => new Catalog { Title = key, Subtitles = g.ToArray<SubtitleJson>() });
            return repository;
        }
        //public Subtitle[] GetSubtitles_1()
        //{
        //    return new Subtitle[]
        //    {
        //           new Subtitle { NameSubtitle = "Вакансии", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Ищут работу", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Курсы, образование", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Деловые контакты", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Юридические услуги", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Финансовые услуги", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Переводы текстов", idTitle=1 },
        //           new Subtitle { NameSubtitle = "Разное", idTitle=1 }
        //    };
        //}
        public Title[] GetTitles()
        {
            var result = repository.GroupBy(
                c => c.Title,
                c => c.Subtitles,
                (key, g) => new Title { NameTitle = key/*, subtitles = g.ToList()*/ }).ToArray<Title>();
            return result;
        }
        //public Title[] GetTitles()
        //{
        //    return new Title[]
        //    {
        //         new Title { NameTitle = "Работа и бизнес" },   /*1*/
        //         new Title { NameTitle = "Эектротехника" },     /*2*/
        //            new Title { NameTitle = "Транспорт" },      /*3*/
        //            new Title { NameTitle = "Одежда, обувь" },
        //            new Title { NameTitle = "Животные" },
        //            new Title { NameTitle = "Недвижимость" },
        //            new Title { NameTitle = "Для дома" },
        //            new Title { NameTitle = "Сельское хозяйство" },
        //            new Title { NameTitle = "Строительство" },
        //            new Title { NameTitle = "Производство" },
        //            new Title { NameTitle = "Отдых, увлечения" }
        //    };
        //}

    }
}
