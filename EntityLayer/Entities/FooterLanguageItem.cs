using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class FooterLanguageItem
    {
        public int FooterLanguageItemID { get; set; }

        public string Title { get; set; }
        public string Description  { get; set; }
        public string PageTitle  { get; set; }
        public string CategoryTitle { get; set; }


        //Footer
        public int FooterID { get; set; }
        public Footer Footer { get; set; }

        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
