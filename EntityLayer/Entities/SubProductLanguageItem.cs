using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SubProductLanguageItem
    {
        public int SubProductLanguageItemID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        //SubProduct
        public int SubProductID { get; set; }
        public SubProduct SubProduct { get; set; }

        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }

        
    }
}
