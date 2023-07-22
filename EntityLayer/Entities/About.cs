using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public string BannerImagePath { get; set; }
        public string AboutImagePath { get; set; }

        public ICollection<AboutLanguageItem> AboutLanguageItems { get; set; }
    }
}
