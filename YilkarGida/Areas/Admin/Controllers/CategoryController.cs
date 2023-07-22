
using BusinessLayer.Abstract;
using DtoLayer.Panel.Category;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YilkarGida.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;
        ILanguageService _languageService;

        public CategoryController(ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService, ILanguageService languageService)
        {
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
            _languageService = languageService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var categories = _categoryService.TGetList();
            var categoryListDto = new List<CategoryListDto>();
            foreach (var item in categories)
            {
                var languageitem = _categoryLanguageItemService.TGetList(x => x.LanguageID == 1 && x.CategoryID == item.CategoryID).FirstOrDefault();
                categoryListDto.Add(new CategoryListDto()
                {
                    CategoryID = item.CategoryID,
                    CategoryName = languageitem.Name,
                    Status = item.Status
                });
            }

            ViewBag.Languages = _languageService.TGetList();


            return View(categoryListDto);
        }

        [HttpGet]
        [Route("EditCategory")]  
        public IActionResult EditCategory(CategoryListPostDto dto)
        {

            var languageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.CategoryID == dto.CategoryID).FirstOrDefault();

            var editCategoryDto = new EditCategoryDto()
            {
                CategoryID = dto.CategoryID,
                Name = languageItem.Name,
            };
            return View(editCategoryDto);
        }

        [HttpPost]
        [Route("EditCategory")]
        public async Task<IActionResult> EditCategory(EditCategoryDto dto)
        {

            var categoryLanguageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.CategoryID == dto.CategoryID).FirstOrDefault();
            var category = _categoryService.TGetByID(categoryLanguageItem.CategoryID);

            categoryLanguageItem.Name = dto.Name;


            if (dto.BannerImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.BannerImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.BannerImage.CopyToAsync(stream);
                category.BannerImagePath = imagename;
            }

            if (dto.CardImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CardImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CardImage.CopyToAsync(stream);
                category.CardImagePath = imagename;
            }

            _categoryService.TUpdate(category);
            _categoryLanguageItemService.TUpdate(categoryLanguageItem);



            return RedirectToAction("Index");
        }


        [Route("ToggleCategoryStatus/{id}")]
        public IActionResult ToggleCategoryStatus(int id)
        {
            var category = _categoryService.TGetByID(id);

            category.Status = !category.Status;
            _categoryService.TUpdate(category);

            return RedirectToAction("Index");
        }
    }
}
