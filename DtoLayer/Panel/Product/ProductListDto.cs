using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Product
{
    public class ProductListDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
