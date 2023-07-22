using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Home
    {
        public int HomeID { get; set; }

        public string BannerImagePath { get; set; }
        public string CategoryImagePath1 { get; set; }
        public string CategoryImagePath2 { get; set; }
        public string CategoryImagePath3 { get; set; }
        public string CategoryImagePath4 { get; set; }

        public string InfoImagePath { get; set; }
        public string ContactImagePath { get; set; }

        

        public ICollection<HomeLanguageItem> HomeLanguageItems { get; set; }
    }
}
