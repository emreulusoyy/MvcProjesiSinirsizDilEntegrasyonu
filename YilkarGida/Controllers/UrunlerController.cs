using BusinessLayer.Abstract;
using DtoLayer.Web;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YilkarGida.Controllers
{
    public class UrunlerController : Controller
    {

        ICategoryLanguageItemService _categoryLanguageItemService;
        ICategoryService _categoryService;
        IProductService _productService;
        IProductLanguageItemService _productLanguageItemService;
        ISubProductService _subProductService;
        ISubProductLanguageItemService _subProductLanguageItemService;

        public UrunlerController(ICategoryLanguageItemService categoryLanguageItemService, IProductLanguageItemService productLanguageItemService, IProductService productService, ICategoryService categoryService, ISubProductService subProductService, ISubProductLanguageItemService subProductLanguageItemService)
        {
            _categoryLanguageItemService = categoryLanguageItemService;
            _productLanguageItemService = productLanguageItemService;
            _productService = productService;
            _categoryService = categoryService;
            _subProductService = subProductService;
            _subProductLanguageItemService = subProductLanguageItemService;
        }

        public IActionResult Index(NavbarCategoryPostDto dto)
        {
            var languageID = dto.LanguageID;
            ViewBag.LanguageID = languageID;
            ViewBag.Link = $"/Urunler/Index?CategoryID={dto.CategoryID}&LanguageID=";

            var category = _categoryService.TGetByID(dto.CategoryID);
            var categoryLanguageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == languageID && x.CategoryID == category.CategoryID).FirstOrDefault();
            var products = _productService.TGetList(x => x.CategoryID == dto.CategoryID && x.Status);

            var categoryListDto = new ProductCategoryListDto()
            {
                CategoryID = category.CategoryID,
                CategoryName = categoryLanguageItem.Name,
                CategoryBannerImagePath = category.BannerImagePath,
                Products = new List<ProductListDto>()
            };

            foreach (var product in products)
            {
                var productLanguageItem = _productLanguageItemService.TGetList(x => x.ProductID == product.ProductID && x.LanguageID == languageID).FirstOrDefault();
                categoryListDto.Products.Add(new ProductListDto()
                {
                    ProductID = productLanguageItem.ProductID,
                    ProductName = productLanguageItem.Name,
                    ProductCardImagePath = product.CardImagePath,
                    SubproductCount = _subProductService.TGetList(x => x.ProductID == productLanguageItem.ProductID).Count()
                });
            }



            return View(categoryListDto);
        }

        public IActionResult ProductList(ProductListPostDto dto)
        {
            var languageID = dto.LanguageID;
            ViewBag.LanguageID = languageID;
            ViewBag.Link = $"/Urunler/ProductList?ProductID={dto.ProductID}&LanguageID=";


            var product = _productService.TGetByID(dto.ProductID);
            var productLanguageItems = _productLanguageItemService.TGetList(x => x.LanguageID == languageID && x.ProductID == product.ProductID).FirstOrDefault();
            var subproducts = _subProductService.TGetList(x => x.ProductID == dto.ProductID && x.Status);

            var subproductListDto = new SubproductByProductListDto()
            {
                ProductID = product.ProductID,
                ProductName = productLanguageItems.Name,
                Subproducts = new List<SubproductListDto>()
            };

            foreach (var subproduct in subproducts)
            {
                var subproductLanguageItem = _subProductLanguageItemService.TGetList(x => x.SubProductID == subproduct.SubProductID && x.LanguageID == languageID).FirstOrDefault();
                subproductListDto.Subproducts.Add(new SubproductListDto()
                {
                    SubproductID  = subproductLanguageItem.SubProductID,
                    SubproductName = subproductLanguageItem.Name,
                    SubproductCardImagePath = subproduct.CardImagePath,

                });
            }
            return View(subproductListDto);
        }


        public IActionResult SubproductDetail(SubproductDetailPostDto dto)
        {
            var languageID = dto.LanguageID;
            ViewBag.LanguageID = languageID;
            ViewBag.Link = $"/Urunler/SubproductDetail?SubproductID={dto.SubproductID}&LanguageID=";


            var subproduct = _subProductService.TGetByID(dto.SubproductID);
            var subproductLanguageItem = _subProductLanguageItemService.TGetList(x=>x.SubProductID == subproduct.SubProductID && x.LanguageID == languageID).FirstOrDefault();

            var subproductDetailDto = new SubproductDetailDto()
            {
                SubProductID = subproduct.SubProductID,
                CardImagePath = subproduct.CardImagePath,
                Name = subproductLanguageItem.Name,
                Detail = subproductLanguageItem.Detail
            };

            return View(subproductDetailDto);
        }
    }
}
