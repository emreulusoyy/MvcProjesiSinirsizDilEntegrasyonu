using BusinessLayer.Abstract;
using DtoLayer.Panel.Employee;
using DtoLayer.Panel.Product;
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
    [Route("Admin/Employee")]
    public class EmployeeController : Controller
    {
        ILanguageService _languageService;
        IEmployeeService _employeeService;
        IEmployeeLanguageItemService _employeeLanguageItemService;

        public EmployeeController(ILanguageService languageService, IEmployeeService employeeService, IEmployeeLanguageItemService employeeLanguageItemService)
        {
            _languageService = languageService;
            _employeeService = employeeService;
            _employeeLanguageItemService = employeeLanguageItemService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var employeeList = _employeeService.TGetList();


            ViewBag.Languages = _languageService.TGetList();

            return View(employeeList);
        }
        [HttpGet]
        [Route("AddEmployee")]
        public IActionResult AddEmployee()
        {

            return View();
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto dto)
        {
            var employee = new Employee()
            {
                Name = dto.Name,
                Status = false,
            };
            if (dto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.Image.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Image.CopyToAsync(stream);
                employee.ImagePath = imagename;
            }

            _employeeService.TInsert(employee);

            int employeeID = employee.EmployeeID;
            var languageList = _languageService.TGetList();
            foreach (var language in languageList)
            {
                _employeeLanguageItemService.TInsert(new EmployeeLanguageItem()
                {
                    LanguageID = language.LanguageID,
                    EmployeeID = employeeID,
                    Title = dto.Title,
                    Description = dto.Description,
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(EmployeeListPostDto dto)
        {
            var employee = _employeeService.TGetByID(dto.EmployeeID);
            var employeeLanguageItem = _employeeLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.EmployeeID == dto.EmployeeID).FirstOrDefault();

            EditEmployeeDto editEmployeeDto = new EditEmployeeDto()
            {
                LanguageID = dto.LanguageID,
                EmployeeID = dto.EmployeeID,
                Name = employee.Name,
                Title = employeeLanguageItem.Title,
                Description = employeeLanguageItem.Description,
            };

            return View(editEmployeeDto);
        }

        [HttpPost]
        [Route("EditEmployee")]
        public async Task<IActionResult> EditEmployee(EditEmployeeDto dto)
        {
            var employee = _employeeService.TGetByID(dto.EmployeeID);
            employee.Name = dto.Name;

            if (dto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extention = Path.GetExtension(dto.Image.FileName);
                var imagename = Guid.NewGuid() + extention;
                var saveLocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await dto.Image.CopyToAsync(stream);
                employee.ImagePath = imagename;
            }
            _employeeService.TUpdate(employee);


            var employeeLanguageItem = _employeeLanguageItemService.TGetList(x => x.LanguageID == dto.LanguageID && x.EmployeeID == dto.EmployeeID).FirstOrDefault();

            employeeLanguageItem.Title = dto.Title;
            employeeLanguageItem.Description = dto.Description;
            _employeeLanguageItemService.TUpdate(employeeLanguageItem);

            return RedirectToAction("Index");
        }

        [Route("ToggleEmployeeStatus/{id}")]
        public IActionResult ToggleEmployeeStatus(int id)
        {
            var employee = _employeeService.TGetByID(id);

            employee.Status = !employee.Status;
            _employeeService.TUpdate(employee);

            return RedirectToAction("Index");
        }

        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.TGetByID(id);
            _employeeService.TDelete(employee);

            return RedirectToAction("Index");
        }
    }
}
