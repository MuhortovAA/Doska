using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class CatalogRepository : ICatalogRepository
    {


        public IEnumerable<Catalog> Catalogs { get; }
        public CatalogRepository()
        {
            //Catalogs = new List<Catalog> {
            //new Catalog {
            //    Title = "Работа и бизнес test",
            //    Subtitles = new List<Subtitle> {
            //        new Subtitle{ NameSubtitle="Вакансии" },
            //        new Subtitle{ NameSubtitle="Ищут работу" },
            //        new Subtitle{ NameSubtitle="Курсы, образованме" },
            //        new Subtitle{ NameSubtitle="Деловые контакты" },
            //        new Subtitle{ NameSubtitle="Юридические услуги" },
            //        new Subtitle{ NameSubtitle="Финансовые услуги" },
            //        new Subtitle{ NameSubtitle="Переводы текстов" },
            //        new Subtitle{ NameSubtitle="Разное" }
            //        }
            //},
            //new Catalog {
            //    Title = "Эектротехника",
            //    Subtitles = new List<Subtitle> {
            //        new Subtitle{ NameSubtitle="Телефоны и связь" },
            //        new Subtitle{ NameSubtitle="Бытовая техника" },
            //        new Subtitle{ NameSubtitle="Компьютеры, оргтехника" },
            //        new Subtitle{ NameSubtitle="Деловые контакты" },
            //        new Subtitle{ NameSubtitle="Юридические услуги" },
            //        new Subtitle{ NameSubtitle="Финансовые услуги" },
            //        new Subtitle{ NameSubtitle="Переводы текстов" },
            //        new Subtitle{ NameSubtitle="Разное" }
            //        }
            //}
        //};
        }
    }
}
