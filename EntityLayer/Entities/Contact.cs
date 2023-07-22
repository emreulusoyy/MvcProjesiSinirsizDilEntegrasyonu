using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string BannerImage { get; set; }
        public string AddresIframe { get; set; }


        //ContactLanguageItem
        public ICollection<ContactLanguageItem> ContactLanguageItems { get; set; }


    }
}
