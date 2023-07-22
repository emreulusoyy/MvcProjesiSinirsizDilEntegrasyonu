using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Web
{
    public class EmployeeListDto
    {
        public int EmployeeID { get; set; }
        public int LanguageID { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
