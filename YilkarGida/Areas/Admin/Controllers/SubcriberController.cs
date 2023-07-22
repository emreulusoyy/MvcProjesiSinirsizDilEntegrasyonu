using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace YilkarGida.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Subcriber")]
    public class SubcriberController : Controller
    {

        ISubcriberService _subcriberService;

        public SubcriberController(ISubcriberService subcriberService)
        {
            _subcriberService = subcriberService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var subcriberList = _subcriberService.TGetList();
            return View(subcriberList);
        }
    }
}
