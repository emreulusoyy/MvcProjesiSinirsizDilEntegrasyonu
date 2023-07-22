using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web.Layout
{
    public class NavbarViewModel
    {
        public string LogoPath { get; set; }
        public string BrandName { get; set; }
        public string HomePage { get; set; }
        public string AboutPage { get; set; }
        public LayoutCategoryDto Category1 { get; set; }
        public LayoutCategoryDto Category2 { get; set; }
        public LayoutCategoryDto Category3 { get; set; }
        public LayoutCategoryDto Category4 { get; set; }
        public LayoutCategoryDto Category5 { get; set; }
        public string ContactPage { get; set; }
        public List<LayoutLanguageDto> Languages { get; set; }
    }
}
