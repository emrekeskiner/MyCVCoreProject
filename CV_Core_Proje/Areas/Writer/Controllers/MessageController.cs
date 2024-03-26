using Microsoft.AspNetCore.Mvc;

namespace MyCVCore.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        public IActionResult UserMessage()
        {
            return View();
        }
    }
}
