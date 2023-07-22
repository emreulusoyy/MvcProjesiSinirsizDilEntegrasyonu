using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Language
    {
        public int LanguageID { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public ICollection<CategoryLanguageItem> CategoryLanguageItems { get; set; }
        public ICollection<ProductLanguageItem> ProductLanguageItems { get; set; }
        public ICollection<SubProductLanguageItem> SubProductLanguageItems { get; set; }
        public ICollection<ContactLanguageItem> ContactLanguageItems { get; set; }
        public ICollection<AboutLanguageItem> AboutLanguageItems { get; set; }
        public ICollection<HomeLanguageItem> HomeLanguageItems { get; set; }
        public ICollection<EmployeeLanguageItem> EmployeeLanguageItems { get; set; }
        public ICollection<FooterLanguageItem> FooterLanguageItems { get; set; }
    }
}
