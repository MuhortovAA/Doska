using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class Ads
    {
        public int Id { get; set; }
        public int IdCatalog { get; set; }
        public string IdCustomer { get; set; }
        public string AdsText { get; set; } = "";
        public DateTime AdsCreate { get; set; } = DateTime.Now;


    }
    public class AdsSelect
    {
        public int Id { get; set; }
        public string AdsText { get; set; } = "";
        public DateTime AdsCreate { get; set; } = DateTime.Now;
        public string NameSubtitle { get; set; }
        public string NameTitle { get; set; }


    }

    public class AdsFind
    {
        public int Id { get; set; }
        public string AdsText { get; set; } = "";
        public DateTime AdsCreate { get; set; } = DateTime.Now;
        public string NameSubtitle { get; set; }
        public string NameTitle { get; set; }





    }

    public class AdsModel
    {
        public int IdCatalog { get; set; }

        public string IdCustomer { get; set; }

        public string AdsText { get; set; } = "";

        public vCatalog catalog { get; set; }
        public string TitlePath => $"\\{catalog.NameTitle}\\{catalog.NameSubtitle}\\";


    }
    public class AdsCreateModel
    {
        public string IdCustomer { get; set; }

        public int IdCatalog { get; set; }

        public string TitlePath { get; set; }

        public string AdsText { get; set; }
    }

}
