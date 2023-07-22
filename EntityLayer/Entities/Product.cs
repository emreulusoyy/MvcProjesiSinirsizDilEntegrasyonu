using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public bool Status { get; set; }
        public string CardImagePath { get; set; }

        //ProductLanguageItem
        public ICollection<ProductLanguageItem> ProductLanguageItems { get; set; }

        //Category
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        //SubProduct
        public ICollection<SubProduct> SubProducts { get; set; }



    }
}
