using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class ProductCategoryListDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryBannerImagePath { get; set; }
        public List<ProductListDto> Products { get; set; }
    }
}
