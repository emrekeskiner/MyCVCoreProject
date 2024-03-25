using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;
using MyCVCore.EntityLayer.Concrete;

namespace MyCVCore.PresentationLayer.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        

        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        [Area("Writer")]
        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }


    }
}
