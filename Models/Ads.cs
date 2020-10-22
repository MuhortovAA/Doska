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
        public string AdsText { get; set; }
        public string Phone { get; set; }
        public DateTime AdsCreate { get; set; }

    }
    public class AdsCreateModel
    {

        public Ads Item { get; set; }
        public vCatalog Catalog { get; set; }
    }
}
