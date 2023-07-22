
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Web.Layout;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YilkarGida.ViewComponents
{
    public class _FooterPartial:ViewComponent
    {

        IFooterService _footerService;
        IFooterLanguageItemDAL _footerLanguageItemDAL;
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;
        IHomeLanguageItemService _homeLanguageItemService;
        IContactLanguageItemService _contactLanguageItemService;
        IAboutLanguageItemService _aboutLanguageItemService;

        public _FooterPartial(IFooterService footerService, IFooterLanguageItemDAL footerLanguageItemDAL, ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService, IHomeLanguageItemService homeLanguageItemService, IContactLanguageItemService contactLanguageItemService, IAboutLanguageItemService aboutLanguageItemService)
        {
            _footerService = footerService;
            _footerLanguageItemDAL = footerLanguageItemDAL;
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
            _homeLanguageItemService = homeLanguageItemService;
            _contactLanguageItemService = contactLanguageItemService;
            _aboutLanguageItemService = aboutLanguageItemService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var languageID = id;
            var footer = _footerService.TGetList().FirstOrDefault();
            var footerLanguageItem = _footerLanguageItemDAL.GetList(x=>x.LanguageID == languageID && x.FooterID == footer.FooterID).FirstOrDefault();


            var footerViewModel = new FooterViewModel()
            {
                Title = footerLanguageItem.Title,
                Description = footerLanguageItem.Description,
                PageTitle = footerLanguageItem.PageTitle,
                CategoryTitle = footerLanguageItem.CategoryTitle,
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
            };

            footerViewModel.HomePage = _homeLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;
            footerViewModel.AboutPage = _aboutLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;
            footerViewModel.ContactPage = _contactLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;

            var categories = _categoryService.TGetList(x => x.Status);
            var categoryDtos = new List<LayoutCategoryDto>();
            foreach (var category in categories)
            {
                var categoryLanguageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == languageID && x.CategoryID == category.CategoryID).FirstOrDefault();
                categoryDtos.Add(new LayoutCategoryDto()
                {
                    CategoryID = category.CategoryID,
                    Name = categoryLanguageItem.Name,
                    Status = category.Status
                });
            }
            footerViewModel.Category1 = categoryDtos[0];
            footerViewModel.Category2 = categoryDtos[1];
            footerViewModel.Category3 = categoryDtos[2];
            footerViewModel.Category4 = categoryDtos[3];
            footerViewModel.Category5 = categoryDtos[4];


            return View(footerViewModel);
        }
    }
}
