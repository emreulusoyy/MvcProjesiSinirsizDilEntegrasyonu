using BusinessLayer.Abstract;
using DtoLayer.Web;
using DtoLayer.Web.Layout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;

namespace YilkarGida.Controllers
{
    
    public class AnaSayfaController : Controller
    {
        IHomeService _homeService;
        IHomeLanguageItemService _homeLanguageItemService;
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;

        public AnaSayfaController(IHomeService homeService, IHomeLanguageItemService homeLanguageItemService, ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService)
        {
            _homeService = homeService;
            _homeLanguageItemService = homeLanguageItemService;
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
        }
        public IActionResult Index(int ID)
        {
            var languageID =  ID;

            ViewBag.LanguageID = languageID;
            ViewBag.Link = "/AnaSayfa/Index";

            var home = _homeService.TGetList().FirstOrDefault();
            var homeLanguageItem = _homeLanguageItemService.TGetList(x=>x.HomeID == home.HomeID && x.LanguageID == languageID
            ).FirstOrDefault();

           
            var homeViewModel = new HomeViewModel()
            {
                BannerImagePath = home.BannerImagePath,
                CategoryImagePath1 = home.CategoryImagePath1,
                CategoryImagePath2 = home.CategoryImagePath2,
                CategoryImagePath3 = home.CategoryImagePath3,
                CategoryImagePath4 = home.CategoryImagePath4,
                InfoImagePath = home.InfoImagePath,
                ContactImagePath = home.ContactImagePath,
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

            };

            var categories = _categoryService.TGetList(x => x.Status);
            var categoryDtos = new List<HomeCategoryDto>();
            foreach (var category in categories)
            {
                var categoryLanguageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == languageID && x.CategoryID == category.CategoryID).FirstOrDefault();
                categoryDtos.Add(new HomeCategoryDto()
                {
                    CategoryID = category.CategoryID,
                    Name = categoryLanguageItem.Name,
                    Status = category.Status,
                    CardImagePath = category.CardImagePath,
                    LanguageID = languageID
                });
            }
            homeViewModel.Category1 = categoryDtos[0];
            homeViewModel.Category2 = categoryDtos[1];
            homeViewModel.Category3 = categoryDtos[2];
            homeViewModel.Category4 = categoryDtos[3];
            homeViewModel.Category5 = categoryDtos[4];

            return View(homeViewModel);
        }
    }
}
