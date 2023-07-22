using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Page
{
    public class EditContactDto
    {

        public string PageName { get; set; }
        public string PageBannerSubtitle { get; set; }

        public string ContactUs { get; set; }
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

        public IFormFile BannerImage { get; set; }
        public string AddresIframe { get; set; }

        public int LanguageID { get; set; }
    }
}
