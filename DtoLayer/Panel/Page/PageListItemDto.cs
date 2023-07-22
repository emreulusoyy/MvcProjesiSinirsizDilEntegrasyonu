using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Panel.Page
{
    public class PageListItemDto
    {
        public int PageID { get; set; }  // 1 = Home, 2 = About, 3 = Contact
        public string PageName { get; set; }
        public string DisplayName { get; set; }
    }
}
