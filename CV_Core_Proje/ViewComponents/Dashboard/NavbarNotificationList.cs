using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Abstract;

namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{
    public class NavbarNotificationList:ViewComponent
    {
        private readonly IAnnouncementDal _announcementDal;

        public NavbarNotificationList(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementDal.GetListAll().OrderByDescending(x=> x.AnnouncementId).Take(4).ToList();
            return View(values);
        }
    }
}
