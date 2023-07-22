using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ContactMessage
    {
        public int ContactMessageID { get; set; }
        public string  FullName { get; set; }
        public string  Subject  { get; set; }
        public string  Email  { get; set; }
        public string  Phone  { get; set; }
        public string  Message { get; set; }
    }
}
