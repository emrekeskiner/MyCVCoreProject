using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WriterUserController : Controller
    {
        private readonly IWriterUserService _writerUserService;

        public WriterUserController(IWriterUserService writerUserService)
        {
            _writerUserService = writerUserService;
        }

        public IActionResult WriterUserPage()
        {
            return View();
        }

        public IActionResult WriterUserList()
        {
            var values = JsonConvert.SerializeObject(_writerUserService.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddWriterUser(WriterUser writerUser)
        {
            var values = JsonConvert.SerializeObject(writerUser);
            _writerUserService.TAdd(writerUser);

            return Json(values);
        }
    }
}
