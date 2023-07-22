using BusinessLayer.Abstract;
using DtoLayer.Web;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YilkarGida.Controllers
{
    public class ContactMessageController : Controller
    {
        ISubcriberService _subcriberService;
        IContactMessageService _contactMessageService;


        public ContactMessageController(ISubcriberService subcriberService, IContactMessageService contactMessageService)
        {
            _subcriberService = subcriberService;
            _contactMessageService = contactMessageService;
        }

        [HttpPost]
        public IActionResult Subcribe(SubcribePostDto dto)
        {
            var subcriber = new Subscriber()
            {
                Email = dto.Email,
            };

            _subcriberService.TInsert(subcriber);

            return RedirectToAction("Index", "Anasayfa", new { id = dto.LanguageID });
        }

        [HttpPost]
        public IActionResult ContactMessage(ContactMessageDto dto)
        {

            var contactMessage = new ContactMessage()
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Message = dto.Message,
                Phone = dto.Phone,
                Subject = dto.Subject,
            };

            _contactMessageService.TInsert(contactMessage);

            return RedirectToAction("Index", "Iletısım", new { id = dto.LanguageID });
        }
    }
}
