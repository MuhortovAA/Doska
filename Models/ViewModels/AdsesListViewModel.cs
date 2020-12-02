using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models.ViewModels
{
    public class AdsesListViewModel
    {
        public IEnumerable<Ads> Adses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
