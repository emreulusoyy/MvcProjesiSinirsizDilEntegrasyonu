using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ContactLanguageItem
    {

        public int ContactLanguageItemID { get; set; }

        public string PageName { get; set; }
        public string PageBannerSubtitle { get; set; }

        public string contactUs { get; set; }
        public string HaveQuestion { get; set; }

        public string LabelAddress { get; set; }
        public string AddressValue { get; set; }

        public string LabelMail { get; set; }
        public string MailValue { get; set; }

        public string LabelPhone { get; set; }
        public string PhoneValue { get; set; }


        public string PlaceholderFullname { get; set; }
        public string PlaceholderSubject { get; set; }
        public string PlaceholderMail { get; set; }
        public string PlaceholderPhone { get; set; }
        public string PlaceholderMessage { get; set; }
        public string SendButton { get; set; }


        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }

        //Contact
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
    }
}
