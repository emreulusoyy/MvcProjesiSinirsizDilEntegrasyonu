using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Migrations;
using DtoLayer.Panel.Product;
using DtoLayer.Panel.Subproduct;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YilkarGida.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductLanguageItemService _productLanguageItemService;
        ISubProductService _subProductService;
        ISubProductLanguageItemService _subProductLanguageItemService;
        ICategoryService _categoryService;
        ICategoryLanguageItemService _categoryLanguageItemService;
        ILanguageService _languageService;

        public ProductController(IProductService productService, IProductLanguageItemService productLanguageItemService, ISubProductService subProductService, ISubProductLanguageItemService subProductLanguageItemService, ICategoryService categoryService, ICategoryLanguageItemService categoryLanguageItemService, ILanguageService languageService)
        {
            _productService = productService;
            _productLanguageItemService = productLanguageItemService;
            _subProductService = subProductService;
            _subProductLanguageItemService = subProductLanguageItemService;
            _categoryService = categoryService;
            _categoryLanguageItemService = categoryLanguageItemService;
            _languageService = languageService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var products = _productService.TGetList();

            var productListDto = new List<ProductListDto>();

            foreach (var item in products)
            {
                var categoryLanguageItem = _categoryLanguageItemService.TGetList(x=>x.CategoryID == item.CategoryID && x.LanguageID == 1).FirstOrDefault();

                var productLanguageItem = _productLanguageItemService.TGetList(x => x.ProductID == item.ProductID && x.LanguageID == 1).FirstOrDefault();


                productListDto.Add(new ProductListDto()
                {
                    ProductID = item.ProductID,
                    CategoryName = categoryLanguageItem.Name,
                    Status = item.Status,
                    Name = productLanguageItem.Name
                });
            }
            ViewBag.Languages = _languageService.TGetList();

            return View(productListDto);
        }

        [HttpGet]
        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            var categories = _categoryService.TGetList();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (var item in categories)
            {
                var categoryLanguageItem = _categoryLanguageItemService.TGetList(x=>x.LanguageID == 1 && x.CategoryID == item.CategoryID).FirstOrDefault();
                var category = new SelectListItem
                {
                    Text = categoryLanguageItem.Name,
                    Value = item.CategoryID.ToString()
                };
                categoryList.Add(category);
            }
            ViewBag.Categories = categoryList;

            return View();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            var product = new Product()
            {
                CategoryID = dto.CategoryID,
                Status = false,
            };
            if (dto.CardImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CardImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CardImage.CopyToAsync(stream);
                product.CardImagePath = imagename;
            }

            _productService.TInsert(product);

            int productID = product.ProductID;
            var languageList = _languageService.TGetList();
            foreach (var language in languageList)
            {
                _productLanguageItemService.TInsert(new ProductLanguageItem()
                {
                    LanguageID = language.LanguageID,
                    ProductID = productID,
                    Name = dto.ProductName
                });
            }
            

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("UpdateProduct")]
        public IActionResult EditProduct(ProductListPostDto dto)
        {
            var product = _productService.TGetByID(dto.ProductID);
            var productLanguageItem = _productLanguageItemService.TGetList(x=>x.LanguageID == dto.LanguageID && x.ProductID == dto.ProductID).FirstOrDefault();

            EditProductDto editProductDto = new EditProductDto()
            {
                LanguageID = dto.LanguageID,
                ProductID = dto.ProductID,
                CategoryID = product.CategoryID,
                ProductName = productLanguageItem.Name
            };


            var categories = _categoryService.TGetList();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (var item in categories)
            {
                var categoryLanguageItem = _categoryLanguageItemService.TGetList(x => x.LanguageID == 1 && x.CategoryID == item.CategoryID).FirstOrDefault();
                var category = new SelectListItem
                {
                    Text = categoryLanguageItem.Name,
                    Value = item.CategoryID.ToString()
                };
                categoryList.Add(category);
            }
            ViewBag.Categories = categoryList;


            return View(editProductDto);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> EditProduct(EditProductDto dto)
        {
            var product = _productService.TGetByID(dto.ProductID);
            product.CategoryID = dto.CategoryID;

            if (dto.CardImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CardImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CardImage.CopyToAsync(stream);
                product.CardImagePath = imagename;
            }
            _productService.TUpdate(product);


            var productLanguageItem = _productLanguageItemService.TGetList(x=>x.LanguageID == dto.LanguageID && x.ProductID == dto.ProductID).FirstOrDefault();

            productLanguageItem.Name = dto.ProductName;
            _productLanguageItemService.TUpdate(productLanguageItem);

            return RedirectToAction("Index");
        }

        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetByID(id);
            _productService.TDelete(product);

            return RedirectToAction("Index");
        }


        [Route("ToggleProductStatus/{id}")]
        public IActionResult ToggleProductStatus(int id)
        {
            var product = _productService.TGetByID(id);

            product.Status = !product.Status;
            _productService.TUpdate(product);

            return RedirectToAction("Index");
        }


        [Route("SubproductList/{id}")]
        public IActionResult SubproductList(int id)
        {
            var subproducts = _subProductService.TGetList(x=>x.ProductID == id);

            var subproductListDto = new List<SubproductListDto>();
            var productLanguageItem = _productLanguageItemService.TGetList(x => x.ProductID == id && x.LanguageID == 1).FirstOrDefault();

            foreach (var item in subproducts)
            {
                
                var subproductLanguageItem = _subProductLanguageItemService.TGetList(x => x.SubProductID == item.SubProductID && x.LanguageID == 1).FirstOrDefault();
                subproductListDto.Add(new SubproductListDto()
                {
                    SubproductID = item.SubProductID,
                    Status = item.Status,
                    ProductName = productLanguageItem.Name,
                    Name = subproductLanguageItem.Name
                });
            }

            
            ViewBag.Languages = _languageService.TGetList();

            return View(subproductListDto);
        }

        [HttpGet]
        [Route("AddSubproduct")]
        public IActionResult AddSubproduct()
        {
            var products = _productService.TGetList();
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in products)
            {
                var productLanguageItem = _productLanguageItemService.TGetList(x => x.LanguageID == 1 && x.ProductID == item.ProductID).FirstOrDefault();
                var product = new SelectListItem
                {
                    Text = productLanguageItem.Name,
                    Value = item.ProductID.ToString()
                };
                productList.Add(product);
            }
            ViewBag.Products = productList;

            return View();
        }

        [HttpPost]
        [Route("AddSubproduct")]
        public async Task<IActionResult> AddSubproduct(AddSubproductDto dto)
        {
            var subproduct = new SubProduct()
            {

                ProductID = dto.ProductID,
                Status = false,
                
               
            };
            if (dto.CardImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CardImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CardImage.CopyToAsync(stream);
                subproduct.CardImagePath = imagename;
            }

            _subProductService.TInsert(subproduct);

            int subProductID = subproduct.SubProductID;
            var languageList = _languageService.TGetList();
            foreach (var language in languageList)
            {
                _subProductLanguageItemService.TInsert(new SubProductLanguageItem()
                {
                    LanguageID = language.LanguageID,
                    SubProductID = subProductID,
                    Name = dto.SubproductName,
                    Detail = dto.Detail
                });
            }

            return RedirectToAction("SubproductList", "Product", new { Area = "Admin", ID = dto.ProductID });
        }


        [HttpGet]
        [Route("EditSubproduct")]
        public IActionResult EditSubproduct(SubproductListPostDto dto)
        {
            var subproduct = _subProductService.TGetByID(dto.SubproductID);
            var subproductLanguageItem = _subProductLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.SubProductID == dto.SubproductID).FirstOrDefault();

            EditSubproductDto editsubProductDto = new EditSubproductDto()
            {
                LanguageID = dto.LanguageID,
                SubproductID = dto.SubproductID,
                ProductID = subproduct.ProductID,
                SubproductName = subproductLanguageItem.Name
            };


            var products = _productService.TGetList();
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in products)
            {
                var productLanguageItem = _productLanguageItemService.TGetList(x => x.LanguageID == 1 && x.ProductID == item.ProductID).FirstOrDefault();
                var product = new SelectListItem
                {
                    Text = productLanguageItem.Name,
                    Value = item.ProductID.ToString()
                };
                productList.Add(product);
            }
            ViewBag.Products = productList;


            return View(editsubProductDto);
        }

        [HttpPost]
        [Route("EditSubproduct")]
        public async Task<IActionResult> EditSubproduct(EditSubproductDto dto)
        {
            var subproduct = _subProductService.TGetByID(dto.SubproductID);
            subproduct.ProductID = dto.ProductID;

            if (dto.CardImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.CardImage.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.CardImage.CopyToAsync(stream);
                subproduct.CardImagePath = imagename;
            }
            _subProductService.TUpdate(subproduct);


            var subproductLanguageItem = _subProductLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.SubProductID == dto.SubproductID).FirstOrDefault();

            subproductLanguageItem.Name = dto.SubproductName;
            subproductLanguageItem.Detail = dto.Detail;
            _subProductLanguageItemService.TUpdate(subproductLanguageItem);

            return RedirectToAction("SubproductList", "Product", new { Area = "Admin", ID = dto.ProductID });
        }

        [Route("DeleteSubproduct/{id}")]
        public IActionResult DeleteSubproduct(int id)
        {
            var subproduct = _subProductService.TGetByID(id);
            _subProductService.TDelete(subproduct);

            return RedirectToAction("SubproductList", "Product", new { Area = "Admin", Id = subproduct.ProductID });
        }


        [Route("ToggleSubproductStatus/{id}")]
        public IActionResult ToggleSubproductStatus(int id)
        {
            var subproduct = _subProductService.TGetByID(id);
            subproduct.Status = !subproduct.Status;
            _subProductService.TUpdate(subproduct);

            return RedirectToAction("SubproductList", "Product", new { Area = "Admin", Id = subproduct.ProductID });
        }


    }
}
