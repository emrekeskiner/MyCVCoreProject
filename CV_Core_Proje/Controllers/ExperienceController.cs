using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult ExperienceList()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Deneyim Listesi";
            ViewBag.sayfa = "Deneyimler";
            ViewBag.url = "/Experience/ExperienceList";
            //---------------------------------

            var values = experienceManager.TGetList(); 

            return View(values);
        }

        [HttpGet]
        public IActionResult EditExperience(int id) 
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Deneyim Güncelle";
            ViewBag.sayfa = "Deneyimler";
            ViewBag.url = "/Experience/ExperienceList";
            //---------------------------------

            var values = experienceManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Deneyim Güncelle";
            ViewBag.sayfa = "Deneyimler";
            ViewBag.url = "/Experience/ExperienceList";
            //---------------------------------

           experienceManager.TUpdate(experience);

            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Deneyim Ekle";
            ViewBag.sayfa = "Deneyimler";
            ViewBag.url = "/Experience/ExperienceList";
            //---------------------------------
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.TGetById(id);
            experienceManager.TDelete(value);
            return RedirectToAction("ExperienceList");
        }
    }
}
