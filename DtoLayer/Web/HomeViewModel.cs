using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class HomeViewModel
    {
        public string BannerImagePath { get; set; }
        public string CategoryImagePath1 { get; set; }
        public string CategoryImagePath2 { get; set; }
        public string CategoryImagePath3 { get; set; }
        public string CategoryImagePath4 { get; set; }

        public string InfoImagePath { get; set; }
        public string ContactImagePath { get; set; }

        //language
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

        public HomeCategoryDto Category1 { get; set; }
        public HomeCategoryDto Category2 { get; set; }
        public HomeCategoryDto Category3 { get; set; }
        public HomeCategoryDto Category4 { get; set; }
        public HomeCategoryDto Category5 { get; set; }

    }

    public class HomeCategoryDto
    {
        public int CategoryID { get; set; }
        public int LanguageID { get; set; }
        public string CardImagePath { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }

}
