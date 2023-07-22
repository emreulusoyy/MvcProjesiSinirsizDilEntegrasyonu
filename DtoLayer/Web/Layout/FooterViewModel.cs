using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web.Layout
{
    public class FooterViewModel
    {
        public string FacebookLink { get; set; }
        public bool FacebookStatus { get; set; }
        public string LinkedinLink { get; set; }
        public bool LinkedinStatus { get; set; }
        public string TwitterLink { get; set; }
        public bool TwitterStatus { get; set; }
        public string GoogleLink { get; set; }
        public bool GoogleStatus { get; set; }
        public string PinterestLink { get; set; }
        public bool PinterestStatus { get; set; }

        public LayoutCategoryDto Category1 { get; set; }
        public LayoutCategoryDto Category2 { get; set; }
        public LayoutCategoryDto Category3 { get; set; }
        public LayoutCategoryDto Category4 { get; set; }
        public LayoutCategoryDto Category5 { get; set; }
        public string HomePage { get; set; }
        public string AboutPage { get; set; }
        public string ContactPage { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public string PageTitle { get; set; }
        public string CategoryTitle { get; set; }
    }
}
