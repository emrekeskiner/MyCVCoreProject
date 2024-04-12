using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.ViewComponents.Footer
{
    public class FooterList:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();

            return View(values);
        }
    }
}
