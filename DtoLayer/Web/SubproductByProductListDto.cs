using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class SubproductByProductListDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductBannerImagePath { get; set; }
        public List<SubproductListDto> Subproducts { get; set; }
    }
}
