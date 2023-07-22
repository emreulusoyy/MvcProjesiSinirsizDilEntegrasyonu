using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class CategoryLanguageItem
    {
        public int CategoryLanguageItemID { get; set; }
        public string Name { get; set; }

        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }

        //Category
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
