using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Footer
    {
        public int FooterID { get; set; }

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


        public List<FooterLanguageItem> FooterLanguageItems { get; set; }
    }
}
