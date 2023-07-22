using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Panel.Page;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace YilkarGida.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Page")]
    public class PageController : Controller
    {
        ILanguageService _languageService;
        IContactService _contactService;
        IContactLanguageItemService _contactLanguageItemService;
        IAboutService _aboutService;
        IAboutLanguageItemService _aboutLanguageItemService;
        IHomeService _homeService;
        IHomeLanguageItemService _homeLanguageItemService;
        IFooterService _footerService;
        IFooterLanguageItemService _footerLanguageItemService;

        public PageController(ILanguageService languageService, IContactService contactService, IContactLanguageItemService contactLanguageItemService, IAboutService aboutService, IAboutLanguageItemService aboutLanguageItemService, IHomeService homeService, IHomeLanguageItemService homeLanguageItemService, IFooterService footerService, IFooterLanguageItemService footerLanguageItemService)
        {
            _languageService = languageService;
            _contactService = contactService;
            _contactLanguageItemService = contactLanguageItemService;
            _aboutService = aboutService;
            _aboutLanguageItemService = aboutLanguageItemService;
            _homeService = homeService;
            _homeLanguageItemService = homeLanguageItemService;
            _footerService = footerService;
            _footerLanguageItemService = footerLanguageItemService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var pageListDto = new List<PageListItemDto>();


            pageListDto.Add(new PageListItemDto()
            {
                PageID = 1,
                PageName = "Home",
                DisplayName = "Anasayfa"
            });

            pageListDto.Add(new PageListItemDto()
            {
                PageID = 2,
                PageName = "About",
                DisplayName = "Hakkımızda"
            });

            pageListDto.Add(new PageListItemDto()
            {
                PageID = 3,
                PageName = "Contact",
                DisplayName = "İletişim"
            });

            pageListDto.Add(new PageListItemDto()
            {
                PageID = 4,
                PageName = "Footer",
                DisplayName = "Alt Kısım"
            });





            ViewBag.Languages = _languageService.TGetList();


            return View(pageListDto);
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact(PageListPostDto dto)
        {
            var contactLanguageItem = _contactLanguageItemService.TGetList(x=>x.LanguageID == dto.LanguageID).FirstOrDefault();
            var contact = _contactService.TGetByID(contactLanguageItem.ContactID);
            var editContactDto = new EditContactDto
            {
                PageName = contactLanguageItem.PageName,
                PageBannerSubtitle = contactLanguageItem.PageBannerSubtitle,
                ContactUs = contactLanguageItem.contactUs,
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
                AddresIframe = contact.AddresIframe

            };
            
            

            return View(editContactDto);
        }

        [HttpPost]
        [Route("Contact")]
        public async Task<IActionResult> Contact(EditContactDto dto)
        {
            var contactLanguageItem = _contactLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            contactLanguageItem.PageName = dto.PageName;
            contactLanguageItem.PageBannerSubtitle = dto.PageBannerSubtitle;
            contactLanguageItem.contactUs = dto.ContactUs;
            contactLanguageItem.HaveQuestion = dto.HaveQuestion;
            contactLanguageItem.LabelAddress = dto.LabelAddress;
            contactLanguageItem.AddressValue = dto.AddressValue;
            contactLanguageItem.LabelMail = dto.LabelMail;
            contactLanguageItem.MailValue = dto.MailValue;
            contactLanguageItem.LabelPhone = dto.LabelPhone;
            contactLanguageItem.PhoneValue = dto.PhoneValue;
            contactLanguageItem.PlaceholderFullname = dto.PlaceholderFullname;
            contactLanguageItem.PlaceholderSubject = dto.PlaceholderSubject;
            contactLanguageItem.PlaceholderMail = dto.PlaceholderMail;
            contactLanguageItem.PlaceholderPhone = dto.PlaceholderPhone;
            contactLanguageItem.PlaceholderMessage = dto.PlaceholderMessage;
            contactLanguageItem.SendButton = dto.SendButton;

            var contact = _contactService.TGetByID(contactLanguageItem.ContactID);

            if (dto.BannerImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.BannerImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.BannerImage.CopyToAsync(stream);
                contact.BannerImage = imagename;
            }
            contact.AddresIframe = dto.AddresIframe;

            _contactLanguageItemService.TUpdate(contactLanguageItem);
            _contactService.TUpdate(contact);

            

            return  RedirectToAction("Index");
        }


        [HttpGet]
        [Route("About")]
        public IActionResult About(PageListPostDto dto)
        {
            var aboutLanguageItem = _aboutLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            var editAboutDto = new EditAboutDto()
            {
                PageName = aboutLanguageItem.PageName,
                PageBannerSubtitle = aboutLanguageItem.PageBannerSubtitle,
                AboutTitle = aboutLanguageItem.AboutTitle,
                AboutDescription = aboutLanguageItem.AboutDescription,
                MissionPretitle = aboutLanguageItem.MissionPretitle,
                MissionTitle = aboutLanguageItem.MissionTitle,
                MissionDescription = aboutLanguageItem.MissionDescription,
                MissionDescriptionCard1 = aboutLanguageItem.MissionDescriptionCard1,
                MissionDescriptionCard2 = aboutLanguageItem.MissionDescriptionCard2,
                MissionDescriptionCard3 = aboutLanguageItem.MissionDescriptionCard3,
                MissionDescriptionCard4 = aboutLanguageItem.MissionDescriptionCard4,
                EmployeeTitle  = aboutLanguageItem.EmployeeTitle,
                EmployeeSubtitle = aboutLanguageItem.EmployeeSubtitle,
                StatisticPretitle = aboutLanguageItem.StatisticPretitle,
                StatisticTitle = aboutLanguageItem.StatisticTitle,
                StatisticDescription = aboutLanguageItem.StatisticDescription,
                StatisticItemName1 = aboutLanguageItem.StatisticItemName1,
                StatisticItemName2 = aboutLanguageItem.StatisticItemName2,
                StatisticItemName3 = aboutLanguageItem.StatisticItemName3,
                StatisticItemName4 = aboutLanguageItem.StatisticItemName4,
                StatisticItemName5 = aboutLanguageItem.StatisticItemName5,
                StatisticItemValue1 = aboutLanguageItem.StatisticItemValue1,
                StatisticItemValue2 = aboutLanguageItem.StatisticItemValue2,
                StatisticItemValue3 = aboutLanguageItem.StatisticItemValue3,
                StatisticItemValue4 = aboutLanguageItem.StatisticItemValue4,
                StatisticItemValue5 = aboutLanguageItem.StatisticItemValue5,
                LanguageID = aboutLanguageItem.LanguageID
            };



            return View(editAboutDto);
        }

        [HttpPost]
        [Route("About")]
        public async Task<IActionResult> About(EditAboutDto dto)
        {
            var aboutLanguageItem = _aboutLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();

            aboutLanguageItem.PageName = dto.PageName;
            aboutLanguageItem.PageBannerSubtitle = dto.PageBannerSubtitle;
            aboutLanguageItem.AboutTitle = dto.AboutTitle;
            aboutLanguageItem.AboutDescription = dto.AboutDescription;
            aboutLanguageItem.MissionPretitle = dto.MissionPretitle;
            aboutLanguageItem.MissionTitle = dto.MissionTitle;
            aboutLanguageItem.MissionDescription = dto.MissionDescription;
            aboutLanguageItem.MissionDescriptionCard1 = dto.MissionDescriptionCard1;
            aboutLanguageItem.MissionDescriptionCard2 = dto.MissionDescriptionCard2;
            aboutLanguageItem.MissionDescriptionCard3 = dto.MissionDescriptionCard3;
            aboutLanguageItem.MissionDescriptionCard4 = dto.MissionDescriptionCard4;
            aboutLanguageItem.EmployeeTitle = dto.EmployeeTitle;
            aboutLanguageItem.EmployeeSubtitle = dto.EmployeeSubtitle;   
            aboutLanguageItem.StatisticPretitle = dto.StatisticPretitle;
            aboutLanguageItem.StatisticTitle = dto.StatisticTitle;
            aboutLanguageItem.StatisticDescription = dto.StatisticDescription;
            aboutLanguageItem.StatisticItemName1 = dto.StatisticItemName1;
            aboutLanguageItem.StatisticItemName2 = dto.StatisticItemName2;
            aboutLanguageItem.StatisticItemName3 = dto.StatisticItemName3;
            aboutLanguageItem.StatisticItemName4 = dto.StatisticItemName4;
            aboutLanguageItem.StatisticItemName5 = dto.StatisticItemName5;
            aboutLanguageItem.StatisticItemValue1 = dto.StatisticItemValue1;
            aboutLanguageItem.StatisticItemValue2 = dto.StatisticItemValue2;
            aboutLanguageItem.StatisticItemValue3 = dto.StatisticItemValue3;
            aboutLanguageItem.StatisticItemValue4 = dto.StatisticItemValue4;
            aboutLanguageItem.StatisticItemValue5 = dto.StatisticItemValue5;
            aboutLanguageItem.LanguageID = dto.LanguageID;

            var about = _aboutService.TGetByID(aboutLanguageItem.AboutID);

            if (dto.BannerImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.BannerImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.BannerImage.CopyToAsync(stream);
                about.BannerImagePath = imagename;
            }
            if (dto.AboutImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.AboutImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.AboutImage.CopyToAsync(stream);
                about.AboutImagePath = imagename;
            }


            _aboutLanguageItemService.TUpdate(aboutLanguageItem);
            _aboutService.TUpdate(about);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Home(PageListPostDto dto)
        {
            var homeLanguageItem = _homeLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            var editHomeDto = new EditHomeDto()
            {
                PageName = homeLanguageItem.PageName,
                BannerPretitle = homeLanguageItem.BannerPretitle,
                BannerTitle = homeLanguageItem.BannerTitle,
                BannerMoreButton = homeLanguageItem.BannerMoreButton,
                CategoryPretitle = homeLanguageItem.CategoryPretitle,
                CategoryTitle = homeLanguageItem.CategoryTitle,
                CategorySubtitle = homeLanguageItem.CategorySubtitle,
                CategoryMoreButton = homeLanguageItem.CategoryMoreButton,
                InfoTitle1 = homeLanguageItem.InfoTitle1,
                InfoDescription1 = homeLanguageItem.InfoDescription1,
                InfoTitle2 = homeLanguageItem.InfoTitle2,
                InfoDescription2 = homeLanguageItem.InfoDescription2,
                InfoTitle3 = homeLanguageItem.InfoTitle3,
                InfoDescription3 = homeLanguageItem.InfoDescription3,
                ProductTitle = homeLanguageItem.ProductTitle,
                ProductViewAllButton = homeLanguageItem.ProductViewAllButton,
                ContactPretitle = homeLanguageItem.ContactPretitle,
                ContactTitle = homeLanguageItem.ContactTitle,
                ContactSubtitle = homeLanguageItem.ContactSubtitle,
                ContactJoinUsPlaceholder = homeLanguageItem.ContactJoinUsPlaceholder,
                ContactSubcribeButton = homeLanguageItem.ContactSubcribeButton,
                LanguageID = homeLanguageItem.LanguageID
            };

            return View(editHomeDto);
        }

        [HttpPost]
        [Route("Home")]
        public async Task<IActionResult> Home(EditHomeDto dto)
        {
            var homeLanguageItem = _homeLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            var home = _homeService.TGetByID(homeLanguageItem.HomeID);

            homeLanguageItem.PageName = dto.PageName;
            homeLanguageItem.BannerPretitle = dto.BannerPretitle;
            homeLanguageItem.BannerTitle = dto.BannerTitle;
            homeLanguageItem.BannerMoreButton = dto.BannerMoreButton;
            homeLanguageItem.CategoryPretitle = dto.CategoryPretitle;
            homeLanguageItem.CategoryTitle = dto.CategoryTitle;
            homeLanguageItem.CategorySubtitle = dto.CategorySubtitle;
            homeLanguageItem.CategoryMoreButton = dto.CategoryMoreButton;
            homeLanguageItem.InfoTitle1 = dto.InfoTitle1;
            homeLanguageItem.InfoDescription1 = dto.InfoDescription1;
            homeLanguageItem.InfoTitle2 = dto.InfoTitle2;
            homeLanguageItem.InfoDescription2 = dto.InfoDescription2;
            homeLanguageItem.InfoTitle3 = dto.InfoTitle3;
            homeLanguageItem.InfoDescription3 = dto.InfoDescription3;
            homeLanguageItem.ProductTitle = dto.ProductTitle;
            homeLanguageItem.ProductViewAllButton = dto.ProductViewAllButton;
            homeLanguageItem.ContactPretitle = dto.ContactPretitle;
            homeLanguageItem.ContactTitle = dto.ContactTitle;
            homeLanguageItem.ContactSubtitle = dto.ContactSubtitle;
            homeLanguageItem.ContactJoinUsPlaceholder = dto.ContactJoinUsPlaceholder;
            homeLanguageItem.ContactSubcribeButton = dto.ContactSubcribeButton;
            homeLanguageItem.LanguageID = dto.LanguageID;


            if (dto.CategoryImagePath1 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CategoryImagePath1.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CategoryImagePath1.CopyToAsync(stream);
                home.CategoryImagePath1 = imagename;
            }
            if (dto.CategoryImagePath2 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CategoryImagePath2.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CategoryImagePath2.CopyToAsync(stream);
                home.CategoryImagePath2 = imagename;
            }
            if (dto.CategoryImagePath3 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CategoryImagePath3.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CategoryImagePath3.CopyToAsync(stream);
                home.CategoryImagePath3 = imagename;
            }
            if (dto.CategoryImagePath4 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CategoryImagePath4.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CategoryImagePath4.CopyToAsync(stream);
                home.CategoryImagePath4 = imagename;
            }
            if (dto.InfoImagePath != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.InfoImagePath.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.InfoImagePath.CopyToAsync(stream);
                home.InfoImagePath = imagename;
            }
            if (dto.ContactImagePath != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.ContactImagePath.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.ContactImagePath.CopyToAsync(stream);
                home.ContactImagePath = imagename;
            }


            _homeLanguageItemService.TUpdate(homeLanguageItem);
            _homeService.TUpdate(home);


            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("Footer")]
        public IActionResult Footer(PageListPostDto dto)
        {
            var footerLanguageItem = _footerLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            var footer = _footerService.TGetByID(footerLanguageItem.FooterID);
            var editFooterDto = new EditFooterDto()
            {
                FacebookLink = footer.FacebookLink,
                FacebookStatus = footer.FacebookStatus,
                LinkedinLink = footer.LinkedinLink,
                LinkedinStatus = footer.LinkedinStatus,
                TwitterLink = footer.TwitterLink,
                TwitterStatus = footer.TwitterStatus,
                GoogleLink = footer.GoogleLink,
                GoogleStatus = footer.GoogleStatus,
                PinterestLink = footer.PinterestLink,
                PinterestStatus = footer.PinterestStatus,
                Title = footerLanguageItem.Title,
                Description = footerLanguageItem.Description,
                PageTitle = footerLanguageItem.PageTitle,
                CategoryTitle = footerLanguageItem.CategoryTitle,
                LanguageID = footerLanguageItem.LanguageID,
            };

            return View(editFooterDto);
        }

        [HttpPost]
        [Route("Footer")]
        public IActionResult Footer(EditFooterDto dto)
        {

            var footerLanguageItem = _footerLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID).FirstOrDefault();
            var footer = _footerService.TGetByID(footerLanguageItem.FooterID);

            footer.FacebookLink = dto.FacebookLink;
            footer.FacebookStatus = dto.FacebookStatus;
            footer.LinkedinLink = dto.LinkedinLink;
            footer.LinkedinStatus = dto.LinkedinStatus;
            footer.TwitterLink = dto.TwitterLink;
            footer.TwitterStatus = dto.TwitterStatus;
            footer.GoogleLink = dto.GoogleLink;
            footer.GoogleStatus = dto.GoogleStatus;
            footer.PinterestLink = dto.PinterestLink;
            footer.PinterestStatus = dto.PinterestStatus;
            footerLanguageItem.Title = dto.Title;
            footerLanguageItem.Description = dto.Description;
            footerLanguageItem.PageTitle = dto.PageTitle;
            footerLanguageItem.CategoryTitle = dto.CategoryTitle;

            _footerLanguageItemService.TUpdate(footerLanguageItem);
            _footerService.TUpdate(footer);

            return RedirectToAction("Index");
        }

    }
}
