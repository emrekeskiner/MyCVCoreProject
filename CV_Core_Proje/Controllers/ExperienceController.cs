using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult ExperienceList()
        {
          

            var values = experienceManager.TGetList(); 

            return View(values);
        }

        [HttpGet]
        public IActionResult EditExperience(int id) 
        {

            var values = experienceManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {

           experienceManager.TUpdate(experience);

            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
           
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
