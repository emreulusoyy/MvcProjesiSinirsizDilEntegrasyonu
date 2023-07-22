using BusinessLayer.Abstract;
using DtoLayer.Web;
using DtoLayer.Web.Employee;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace YilkarGida.Controllers
{
    public class HakkindaController : Controller
    {
        IAboutService _aboutService;
        IAboutLanguageItemService _aboutLanguageItemService;
        IEmployeeService _employeeService;
        IEmployeeLanguageItemService _employeeLanguageItemService;

        public HakkindaController(IAboutService aboutService, IAboutLanguageItemService aboutLanguageItemService, IEmployeeService employeeService, IEmployeeLanguageItemService employeeLanguageItemService)
        {
            _aboutService = aboutService;
            _aboutLanguageItemService = aboutLanguageItemService;
            _employeeService = employeeService;
            _employeeLanguageItemService = employeeLanguageItemService;
        }

        public IActionResult Index(int ID)
        {
            var languageID = ID;

            ViewBag.LanguageID = languageID;
            ViewBag.Link = "/Hakkinda/Index";

            var about = _aboutService.TGetList().FirstOrDefault();
            var aboutLanguageItem = _aboutLanguageItemService.TGetList(x=>x.AboutID==about.AboutID && x.LanguageID == languageID).FirstOrDefault();

            var aboutViewModel = new AboutViewModel()
            {
                BannerImagePath = about.BannerImagePath,
                AboutImagePath = about.AboutImagePath,
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
                EmployeeTitle = aboutLanguageItem.EmployeeTitle,
                EmployeeSubtitle = aboutLanguageItem.EmployeeSubtitle,
                Employees = new List<EmployeeListDto>(),
                StatisticPretitle = aboutLanguageItem.StatisticPretitle,
                StatisticTitle = aboutLanguageItem.StatisticTitle,
                StatisticDescription = aboutLanguageItem.StatisticDescription,
                StatisticItemName1 = aboutLanguageItem.StatisticItemName1,
                StatisticItemValue1 = aboutLanguageItem.StatisticItemValue1,
                StatisticItemName2 = aboutLanguageItem.StatisticItemName2,
                StatisticItemValue2 = aboutLanguageItem.StatisticItemValue2,
                StatisticItemName3 = aboutLanguageItem.StatisticItemName3,
                StatisticItemValue3 = aboutLanguageItem.StatisticItemValue3,
                StatisticItemName4 = aboutLanguageItem.StatisticItemName4,
                StatisticItemValue4 = aboutLanguageItem.StatisticItemValue4,
                StatisticItemName5 = aboutLanguageItem.StatisticItemName5,
                StatisticItemValue5 = aboutLanguageItem.StatisticItemValue5,

            };

            var employees = _employeeService.TGetList(x=>x.Status);
            foreach (var employee in employees)
            {
                var employeeLanguageItem = _employeeLanguageItemService.TGetList(x=>x.LanguageID == languageID && x.EmployeeID == employee.EmployeeID).FirstOrDefault();
                var employeeListDto = new EmployeeListDto()
                {
                    EmployeeID = employee.EmployeeID,
                    LanguageID = languageID,
                    ImagePath = employee.ImagePath,
                    Name = employee.Name,
                    Title = employeeLanguageItem.Title
                };
                aboutViewModel.Employees.Add(employeeListDto);
            }

            return View(aboutViewModel);
        }


        public IActionResult EmployeeDetail(EmployeeDetailPostDto dto)
        {
            var languageID = dto.LanguageID;

            ViewBag.LanguageID = languageID;
            ViewBag.Link = $"/Hakkinda/EmployeeDetail?EmployeeID={dto.EmployeeID}&LanguageID=";


            var employee = _employeeService.TGetByID(dto.EmployeeID);
            var employeeLanguageItem = _employeeLanguageItemService.TGetList(x=>x.LanguageID == languageID && x.EmployeeID == employee.EmployeeID).FirstOrDefault();

            var employeeDetailDto = new EmployeeDetailDto()
            {
                ImagePath = employee.ImagePath,
                Name = employee.Name,
                Title = employeeLanguageItem.Title,
                Description = employeeLanguageItem.Description
            };



            return View(employeeDetailDto);
        }
    }
}
