using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Abstract;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementController(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        [HttpGet]
        public IActionResult AdminAnnouncementDetails(int id)
        {
            var values = _announcementDal.GetById(id);
            return View(values);
        }

        public IActionResult AdminAnnouncementList()
        {
            var values = _announcementDal.GetListAll();
            return View(values);
        }
    }
}
