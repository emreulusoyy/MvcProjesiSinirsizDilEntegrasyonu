using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ProductLanguageItem
    {
        public int ProductLanguageItemID { get; set; }
        public string Name { get; set; }

        //Product
        public int ProductID { get; set; }
        public Product Product { get; set; }


        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
