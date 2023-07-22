using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class SubproductDetailDto
    {
        public int SubProductID { get; set; }
        public string CardImagePath { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
