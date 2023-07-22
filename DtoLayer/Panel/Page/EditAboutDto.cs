using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Page
{
    public class EditAboutDto
    {
        public string PageName { get; set; }
        public string PageBannerSubtitle { get; set; }

        public IFormFile BannerImage { get; set; }
        public IFormFile AboutImage { get; set; }

        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }

        public string MissionPretitle { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string MissionDescriptionCard1 { get; set; }
        public string MissionDescriptionCard2 { get; set; }
        public string MissionDescriptionCard3 { get; set; }
        public string MissionDescriptionCard4 { get; set; }

        public string EmployeeTitle { get; set; }
        public string EmployeeSubtitle { get; set; }

        public string StatisticPretitle { get; set; }
        public string StatisticTitle { get; set; }
        public string StatisticDescription { get; set; }
        public string StatisticItemName1 { get; set; }
        public string StatisticItemValue1 { get; set; }
        public string StatisticItemName2 { get; set; }
        public string StatisticItemValue2 { get; set; }
        public string StatisticItemName3 { get; set; }
        public string StatisticItemValue3 { get; set; }
        public string StatisticItemName4 { get; set; }
        public string StatisticItemValue4 { get; set; }
        public string StatisticItemName5 { get; set; }
        public string StatisticItemValue5 { get; set; }

        public int LanguageID { get; set; }
    }
}
