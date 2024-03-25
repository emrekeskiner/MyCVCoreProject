using Microsoft.AspNetCore.Mvc;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult DashboardPage()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Dashboard";
            ViewBag.sayfa = "İstatislik Sayfası";
            ViewBag.url = "#";
            //---------------------------------


            return View();
        }
    }
}
