using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        [HttpGet]
        public IActionResult EditFeature()
        {

            var values = featureManager.TGetById(3);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
           
                featureManager.TUpdate(feature);

                return RedirectToAction("EditFeature");
          
        }
    }
}
