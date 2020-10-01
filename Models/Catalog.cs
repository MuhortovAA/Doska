using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Models
{
    public class Catalog
    {
        public string Title { get; set; }
        public IEnumerable<Subtitle> Subtitles { get; set; }

    }
    public class Subtitle
    {
        public string NameSubtitle { get; set; }
    }
}
