using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class ProductListDto
    {
        public int ProductID { get; set; }
        public string ProductCardImagePath { get; set; }
        public string ProductName  { get; set; }
        public int SubproductCount  { get; set; }
        
    }
}
