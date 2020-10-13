using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    [Keyless]
    public class Catalog
    {
        public int id { get; set; }
        public int idTitle { get; set; }
        public int idSubtitle { get; set; }
        //public IEnumerable<Subtitle> Subtitles { get; set; }

    }
    public class Subtitle
    {
        public int id { get; set; }
        public string NameSubtitle { get; set; }
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
        public Title[] GetTitle_1() { return new Title[] { new Title { NameTitle = "Работа и бизнес" } }; }
        public Subtitle[] GetSubtitles_1()
        {
            return new Subtitle[]
            {
                   new Subtitle { NameSubtitle = "Вакансии" },
                   new Subtitle { NameSubtitle = "Ищут работу" },
                   new Subtitle { NameSubtitle = "Курсы, образование" },
                   new Subtitle { NameSubtitle = "Деловые контакты" },
                   new Subtitle { NameSubtitle = "Юридические услуги" },
                   new Subtitle { NameSubtitle = "Финансовые услуги" },
                   new Subtitle { NameSubtitle = "Переводы текстов" },
                   new Subtitle { NameSubtitle = "Разное" }
            };
        }
        public Catalog[] GetCatalog_1()
        {
            return new Catalog[]
            {
                new Catalog { idSubtitle = 1, idTitle = 1 },
                new Catalog { idSubtitle = 2, idTitle = 1 },
                    new Catalog { idSubtitle = 3, idTitle = 1 },
                    new Catalog { idSubtitle = 4, idTitle = 1 },
                    new Catalog { idSubtitle = 5, idTitle = 1 },
                    new Catalog { idSubtitle = 6, idTitle = 1 },
                    new Catalog { idSubtitle = 7, idTitle = 1 },
                    new Catalog { idSubtitle = 8, idTitle = 1 }
            };
        }
        public Title[] GetTitles()
        {
            return new Title[]
            {
                 new Title { NameTitle = "Работа и бизнес" },
                 new Title { NameTitle = "Эектротехника" },
                    new Title { NameTitle = "Транспорт" },
                    new Title { NameTitle = "Одежда, обувь" },
                    new Title { NameTitle = "Животные" },
                    new Title { NameTitle = "Недвижимость" },
                    new Title { NameTitle = "Для дома" },
                    new Title { NameTitle = "Сельское хозяйство" },
                    new Title { NameTitle = "Строительство" },
                    new Title { NameTitle = "Производство" },
                    new Title { NameTitle = "Отдых, увлечения" }
            };
        }

    }
}
