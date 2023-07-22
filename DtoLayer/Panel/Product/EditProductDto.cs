using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Product
{
    public class EditProductDto
    {
        public int ProductID { get; set; }
        public int LanguageID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public IFormFile CardImage { get; set; }
    }
}
