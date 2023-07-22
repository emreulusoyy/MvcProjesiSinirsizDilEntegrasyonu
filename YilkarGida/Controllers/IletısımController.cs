using BusinessLayer.Abstract;
using DtoLayer.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace YilkarGida.Controllers
{
    public class IletısımController : Controller
    {
        IContactService _contactService;
        IContactLanguageItemService _contactLanguageItemService;

        public IletısımController(IContactService contactService, IContactLanguageItemService contactLanguageItemService)
        {
            _contactService = contactService;
            _contactLanguageItemService = contactLanguageItemService;
        }

        public IActionResult Index(int ID)
        {
            var languageID = ID;

            ViewBag.LanguageID = languageID;
            ViewBag.Link = "/Iletısım/Index";

            var contact = _contactService.TGetList().FirstOrDefault();
            var contactLanguageItem = _contactLanguageItemService.TGetList(x=>x.ContactID == contact.ContactID && x.LanguageID == languageID).FirstOrDefault();
            var contactViewModel = new ContactViewModel()
            {
                BannerImage = contact.BannerImage,
                AddresIframe = contact.AddresIframe,
                PageName = contactLanguageItem.PageName,
                PageBannerSubtitle = contactLanguageItem.PageBannerSubtitle,
                contactUs = contactLanguageItem.contactUs,
                HaveQuestion = contactLanguageItem.HaveQuestion,
                LabelAddress = contactLanguageItem.LabelAddress,
                AddressValue = contactLanguageItem.AddressValue,
                LabelMail = contactLanguageItem.LabelMail,
                MailValue = contactLanguageItem.MailValue,
                LabelPhone = contactLanguageItem.LabelPhone,
                PhoneValue = contactLanguageItem.PhoneValue,
                PlaceholderFullname = contactLanguageItem.PlaceholderFullname,
                PlaceholderSubject = contactLanguageItem.PlaceholderSubject,
                PlaceholderMail = contactLanguageItem.PlaceholderMail,
                PlaceholderPhone = contactLanguageItem.PlaceholderPhone,
                PlaceholderMessage = contactLanguageItem.PlaceholderMessage,
                SendButton = contactLanguageItem.SendButton,
                
            };

            return View(contactViewModel);
        }


    }
}
