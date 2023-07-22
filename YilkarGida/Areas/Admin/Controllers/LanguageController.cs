using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace YilkarGida.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Language")]
    public class LanguageController : Controller
    {

        ILanguageService _languageService;
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;
        IProductService _productService;
        IProductLanguageItemService _productLanguageItemService;
        ISubProductService _subProductService;
        ISubProductLanguageItemService _subProductLanguageItemService;
        IHomeService _homeService;
        IHomeLanguageItemService _homeLanguageItemService;
        IAboutService _aboutService;
        IAboutLanguageItemService _aboutLanguageItemService;
        IContactService _contactService;
        IContactLanguageItemService _contactLanguageItemService;
        IEmployeeService _employeeService;
        IEmployeeLanguageItemService _employeeLanguageItemService;
        IFooterService _footerService;
        IFooterLanguageItemService _footerLanguageItemService;

        public LanguageController(ILanguageService languageService, ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService, IProductService productService, IProductLanguageItemService productLanguageItemService, ISubProductService subProductService, ISubProductLanguageItemService subProductLanguageItemService, IHomeService homeService, IHomeLanguageItemService homeLanguageItemService, IAboutService aboutService, IAboutLanguageItemService aboutLanguageItemService, IContactService contactService, IContactLanguageItemService contactLanguageItemService, IEmployeeService employeeService, IEmployeeLanguageItemService employeeLanguageItemService, IFooterService footerService, IFooterLanguageItemService footerLanguageItemService)
        {
            _languageService = languageService;
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
            _productService = productService;
            _productLanguageItemService = productLanguageItemService;
            _subProductService = subProductService;
            _subProductLanguageItemService = subProductLanguageItemService;
            _homeService = homeService;
            _homeLanguageItemService = homeLanguageItemService;
            _aboutService = aboutService;
            _aboutLanguageItemService = aboutLanguageItemService;
            _contactService = contactService;
            _contactLanguageItemService = contactLanguageItemService;
            _employeeService = employeeService;
            _employeeLanguageItemService = employeeLanguageItemService;
            _footerService = footerService;
            _footerLanguageItemService = footerLanguageItemService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var languageList = _languageService.TGetList();
            return View(languageList);
        }

        [HttpGet]
        [Route("AddLanguage")]
        public IActionResult AddLanguage()
        {
            return View();
        }

        [HttpPost]
        [Route("AddLanguage")]
        public IActionResult AddLanguage(Language language)
        {
            Language mylanguage = language;
            language.Status = false;
            _languageService.TInsert(mylanguage);

            var categoryList = _categoryService.TGetList();
            foreach (var category in categoryList)
            {
                _categoryLanguageItemService.TInsert(new CategoryLanguageItem
                {
                    CategoryID = category.CategoryID,
                    LanguageID = language.LanguageID,
                });
            }

            var productList = _productService.TGetList();
            foreach (var product in productList)
            {
                _productLanguageItemService.TInsert(new ProductLanguageItem
                {
                    ProductID = product.ProductID,
                    LanguageID = language.LanguageID,
                });
            }

            var subproductList = _subProductService.TGetList();
            foreach (var subproduct in subproductList)
            {
                _subProductLanguageItemService.TInsert(new SubProductLanguageItem
                {
                    SubProductID = subproduct.SubProductID,
                    LanguageID = language.LanguageID,
                });
            }

            var employeeList = _employeeService.TGetList();
            foreach (var employee in employeeList)
            {
                _employeeLanguageItemService.TInsert(new EmployeeLanguageItem
                {
                    EmployeeID = employee.EmployeeID,
                    LanguageID = language.LanguageID,
                });
            }

            var home = _homeService.TGetList().FirstOrDefault();
            _homeLanguageItemService.TInsert(new HomeLanguageItem()
            {
                HomeID = home.HomeID,
                LanguageID = language.LanguageID,
            });

            var about = _aboutService.TGetList().FirstOrDefault();
            _aboutLanguageItemService.TInsert(new AboutLanguageItem()
            {
                AboutID = about.AboutID,
                LanguageID = language.LanguageID,
            });

            var contact = _contactService.TGetList().FirstOrDefault();
            _contactLanguageItemService.TInsert(new ContactLanguageItem()
            {
                ContactID = contact.ContactID,
                LanguageID = language.LanguageID,
            });

            var footer = _footerService.TGetList().FirstOrDefault();
            _footerLanguageItemService.TInsert(new FooterLanguageItem()
            {
                FooterID = footer.FooterID,
                LanguageID = language.LanguageID,
            });


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditLanguage/{LanguageID}")]
        public IActionResult EditLanguage(int LanguageID)
        {
            var language = _languageService.TGetByID(LanguageID);
            return View(language);
        }

        [HttpPost]
        [Route("EditLanguage/{LanguageID}")]
        public IActionResult EditLanguage(Language language)
        {
            _languageService.TUpdate(language);
            return RedirectToAction("Index");
        }

        [Route("ToggleLanguageStatus/{id}")]
        public IActionResult ToggleLanguageStatus(int id)
        {
            var language = _languageService.TGetByID(id);

            language.Status = !language.Status;
            _languageService.TUpdate(language);

            return RedirectToAction("Index");
        }


    }
}
