using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class EmployeeLanguageItem
    {
        public int EmployeeLanguageItemID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


        //Language
        public int LanguageID { get; set; }
        public Language Language { get; set; }

        //Employee
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
