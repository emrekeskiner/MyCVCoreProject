using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubContentController : Controller
    {
        private readonly IContactService _contactService;

        public SubContentController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult SubContentMain()
        {
            var values = _contactService.TGetList().FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public IActionResult SubContentMain(Contact contact)
        {
            //var values = _contactService.TGetList().FirstOrDefault();
            _contactService.TUpdate(contact);
            return RedirectToAction("SubContentMain");
        }

    }
}
