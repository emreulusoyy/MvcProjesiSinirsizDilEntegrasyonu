using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Subproduct
{
    public class SubproductListDto
    {
        public int SubproductID { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public bool Status { get; set; }
    }
}
