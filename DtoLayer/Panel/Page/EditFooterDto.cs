using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Page
{
    public class EditFooterDto
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


        public string Title { get; set; }
        public string Description { get; set; }
        public string PageTitle { get; set; }
        public string CategoryTitle { get; set; }

        public int LanguageID { get; set; }


    }
}
