using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult SkillList()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Yetenek Listesi";
            ViewBag.sayfa = "Yetenekler";
            ViewBag.url = "/Skill/SkillList";
            //---------------------------------
            var values = skillManager.TGetList();
           
            return View(values);
        }

        [HttpGet]

        public IActionResult AddSkill()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Yetenek Ekle";
            ViewBag.sayfa = "Yetenekler";
            ViewBag.url = "/Skill/SkillList";
            //---------------------------------
            return View();
        }

        [HttpPost]

        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = skillManager.TGetById(id);
            skillManager.TDelete(value);
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {

            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Yetenek Güncelle";
            ViewBag.sayfa = "Yetenekler";
            ViewBag.url = "/Skill/SkillList";
            //---------------------------------
            var value = skillManager.TGetById(id);
            return View(value);  
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);

            return RedirectToAction("SkillList");
        }

    }
}
