using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());


        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.TGetList();
            var liste = values.Where(x=>x.Status==true).ToList();
            return View(liste);
        }
    }
}
