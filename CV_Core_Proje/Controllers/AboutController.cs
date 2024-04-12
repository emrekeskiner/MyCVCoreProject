using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult EditAbout()
        {

            var values = aboutManager.TGetById(1);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {

            aboutManager.TUpdate(about);

            return RedirectToAction("EditAbout");

        }
    }
}
