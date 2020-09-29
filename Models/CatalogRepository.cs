using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class CatalogRepository : ICatalogRepository
    {
        public IEnumerable<Catalog> Catalogs => new List<Catalog> { 
            new Catalog { Title = "Работа и бизнес", Subtitle = "Вакансии" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Ищут работу" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Курсы, образованме" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Деловые контакты" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Юридические услуги" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Финансовые услуги" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Переводы текстов" },
            new Catalog { Title = "Работа и бизнес", Subtitle = "Разное" },
            new Catalog { Title = "Эектротехника", Subtitle = "Телефоны и связь" },
            new Catalog { Title = "Эектротехника", Subtitle = "Бытовая техника" },
            new Catalog { Title = "Эектротехника", Subtitle = "Компьютеры, оргтехника" },

        };
    }
}
