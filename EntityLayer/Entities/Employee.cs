using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; }


        ICollection<EmployeeLanguageItem> EmployeeLanguageItems { get; set;}
    }
}
