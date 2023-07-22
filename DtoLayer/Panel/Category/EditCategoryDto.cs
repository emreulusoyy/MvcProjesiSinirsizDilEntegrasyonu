using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Category
{
    public class EditCategoryDto
    {
        public int CategoryID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public IFormFile BannerImage { get; set; }
        public IFormFile CardImage { get; set; }
    }
}
