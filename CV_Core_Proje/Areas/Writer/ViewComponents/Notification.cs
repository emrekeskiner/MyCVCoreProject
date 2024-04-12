using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Abstract;

namespace MyCVCore.PresentationLayer.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        private readonly IAnnouncementDal _announcementDal;

        public Notification(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementDal.GetListAll().Take(3).ToList();
            return View(values);
        }
    }
}
