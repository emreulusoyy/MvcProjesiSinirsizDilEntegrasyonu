using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Subproduct
{
    public class AddSubproductDto
    {
        public int ProductID { get; set; }
        public string SubproductName { get; set; }
        public IFormFile CardImage { get; set; }
        public string Detail { get; set; }
    }
}
