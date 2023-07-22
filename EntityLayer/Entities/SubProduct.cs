using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SubProduct
    {
        public int SubProductID { get; set; }
        public bool Status { get; set; }
        public string CardImagePath { get; set; }

        //Product
        public int ProductID { get; set; }
        public Product Product { get; set; }


        //SubProductLanguageItem
        public ICollection<SubProductLanguageItem> SubProductLanguageItems { get; set; }
    }
}
