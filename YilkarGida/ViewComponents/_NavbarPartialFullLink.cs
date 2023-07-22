using BusinessLayer.Abstract;
using DtoLayer.Web.Layout;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YilkarGida.ViewComponents
{
    public class _NavbarPartialFullLink:ViewComponent
    {
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;
        IHomeLanguageItemService _homeLanguageItemService;
        IContactLanguageItemService _contactLanguageItemService;
        IAboutLanguageItemService _aboutLanguageItemService;
        ILanguageService _languageService;

        public _NavbarPartialFullLink(ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService, IHomeLanguageItemService homeLanguageItemService, IContactLanguageItemService contactLanguageItemService, IAboutLanguageItemService aboutLanguageItemService, ILanguageService languageService)
        {
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
            _homeLanguageItemService = homeLanguageItemService;
            _contactLanguageItemService = contactLanguageItemService;
            _aboutLanguageItemService = aboutLanguageItemService;
            _languageService = languageService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var languageID = id;
            var navbarViewModel = new NavbarViewModel();
            navbarViewModel.LogoPath = "logo.jpeg";
            navbarViewModel.BrandName = "Yılkar2 Gıda";

            navbarViewModel.HomePage = _homeLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;
            navbarViewModel.AboutPage = _aboutLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;
            navbarViewModel.ContactPage = _contactLanguageItemService.TGetList(x => x.LanguageID == languageID).FirstOrDefault().PageName;

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
            navbarViewModel.Category1 = categoryDtos[0];
            navbarViewModel.Category2 = categoryDtos[1];
            navbarViewModel.Category3 = categoryDtos[2];
            navbarViewModel.Category4 = categoryDtos[3];
            navbarViewModel.Category5 = categoryDtos[4];
            navbarViewModel.Languages = new List<LayoutLanguageDto>();

            var langauges = _languageService.TGetList(X => X.Status);

            foreach (var language in langauges)
            {
                navbarViewModel.Languages.Add(new LayoutLanguageDto()
                {
                    LangaugeID = language.LanguageID,
                    LanguageCode = language.Code
                });
            }

            return View(navbarViewModel);
        }
        }
}
