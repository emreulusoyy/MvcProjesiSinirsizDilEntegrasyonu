using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Page
{
    public class EditHomeDto
    {
        public string PageName { get; set; }
        public string BannerPretitle { get; set; }
        public string BannerTitle { get; set; }
        public string BannerMoreButton { get; set; }


        public string CategoryPretitle { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySubtitle { get; set; }
        public string CategoryMoreButton { get; set; }



        public string InfoTitle1 { get; set; }
        public string InfoDescription1 { get; set; }
        public string InfoTitle2 { get; set; }
        public string InfoDescription2 { get; set; }
        public string InfoTitle3 { get; set; }
        public string InfoDescription3 { get; set; }

        public string ProductTitle { get; set; }
        public string ProductViewAllButton { get; set; }

        public string ContactPretitle { get; set; }
        public string ContactTitle { get; set; }
        public string ContactSubtitle { get; set; }
        public string ContactJoinUsPlaceholder { get; set; }
        public string ContactSubcribeButton { get; set; }


        public IFormFile CategoryImagePath1 { get; set; }
        public IFormFile CategoryImagePath2 { get; set; }
        public IFormFile CategoryImagePath3 { get; set; }
        public IFormFile CategoryImagePath4 { get; set; }
        public IFormFile InfoImagePath { get; set; }
        public IFormFile ContactImagePath { get; set; }


        public int LanguageID { get; set; }
    }
}
