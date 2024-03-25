using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        [HttpGet]
        public IActionResult EditFeature()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Başlık Güncelle";
            ViewBag.sayfa = "Başlık Sayfası";
            ViewBag.url = "#";
            //---------------------------------

            var values = featureManager.TGetById(3);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Başlık Güncelle";
            ViewBag.sayfa = "Başlık Sayfası";
            ViewBag.url = "#";
            //---------------------------------
           
                featureManager.TUpdate(feature);

                return RedirectToAction("EditFeature");
          
        }
    }
}
