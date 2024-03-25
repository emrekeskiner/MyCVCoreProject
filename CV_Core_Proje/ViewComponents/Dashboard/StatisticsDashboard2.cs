using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Context;

namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {

        CvContext context = new CvContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.projeSayisi = context.Portfolios.Count();
            ViewBag.hizmetlerSayisi = context.Services.Count();
            ViewBag.mesajSayisi = context.Messages.Count();
            return View();
        }
    }
}
