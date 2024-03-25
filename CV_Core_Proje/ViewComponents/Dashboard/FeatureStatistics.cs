using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Context;

namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{

    public class FeatureStatistics : ViewComponent
    {
        CvContext context = new CvContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.yetenekSayisi = context.Skills.Count();
            ViewBag.deneyimSayisi = context.Experiences.Count();
            ViewBag.okunmamisMesajSayisi = context.Messages.Where(x=> x.Status==false).Count();
            ViewBag.okunmusMesajSayisi = context.Messages.Where(x=> x.Status==true).Count();

            return View();
        }
    }
}
