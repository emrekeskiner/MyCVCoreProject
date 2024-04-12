using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;
using MyCVCore.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult ExperiencePage()
        {
            return View();
        }

        public IActionResult ExperienceList()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            var values = JsonConvert.SerializeObject(experience);
            experienceManager.TAdd(experience);

            return Json(values);
        }

        public IActionResult GetById(int id)
        {
            var values = experienceManager.TGetById(id);
            if (values == null) {
                string json = JsonConvert.SerializeObject("Kayıt yok");
                return Json(json);
            }
            var jsonValue=JsonConvert.SerializeObject(values);
            return Json(jsonValue);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            if (values == null)
            {
                string json = JsonConvert.SerializeObject("Kayıt yok");
                return Json(json);
            }
            experienceManager.TDelete(values);
            return Ok();
        }
    }
}
