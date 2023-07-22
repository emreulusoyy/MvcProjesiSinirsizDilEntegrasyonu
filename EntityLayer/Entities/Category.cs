using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }     
        public bool Status { get; set; }
        public string BannerImagePath { get; set; }
        public string CardImagePath { get; set; }

        //CategoryLanguageItem
        public ICollection<CategoryLanguageItem> CategoryLanguageItems { get; set; }

        //Product
        public ICollection<Product> Products { get; set; }
    }
}
