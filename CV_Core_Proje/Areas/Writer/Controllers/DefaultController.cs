using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;
using MyCVCore.EntityLayer.Concrete;

namespace MyCVCore.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    public class DefaultController : Controller
    {
        

        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        
        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            var values = announcementManager.TGetById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            announcementManager.TAdd(announcement);
            return RedirectToAction("Index","Default");
        }
    }
}
