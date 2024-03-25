using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult EditAbout()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hakkımda Güncelle";
            ViewBag.sayfa = "Hakkımda Sayfası";
            ViewBag.url = "#";
            //---------------------------------

            var values = aboutManager.TGetById(1);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hakkımda Güncelle";
            ViewBag.sayfa = "Hakkımda Sayfası";
            ViewBag.url = "#";
            //---------------------------------

            aboutManager.TUpdate(about);

            return RedirectToAction("EditAbout");

        }
    }
}
