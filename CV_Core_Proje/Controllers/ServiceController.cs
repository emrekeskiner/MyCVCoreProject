using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult ServiceList()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hizmet Listesi";
            ViewBag.sayfa = "Hizmetler";
            ViewBag.url = "/Service/ServiceList";
            //---------------------------------

            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hizmet Güncelle";
            ViewBag.sayfa = "Hizmetler";
            ViewBag.url = "/Service/ServiceList";
            //---------------------------------

            var values = serviceManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hizmet Güncelle";
            ViewBag.sayfa = "Hizmetler";
            ViewBag.url = "/Service/ServiceList";
            //---------------------------------
       
                serviceManager.TUpdate(service);

                return RedirectToAction("ServiceList");
         

        }

        [HttpGet]
        public IActionResult AddService()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hizmet Ekle";
            ViewBag.sayfa = "Hizmetler";
            ViewBag.url = "/Service/ServiceList";
            //---------------------------------
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Hizmet Ekle";
            ViewBag.sayfa = "Hizmetler";
            ViewBag.url = "/Service/ServiceList";
            //---------------------------------


           
                serviceManager.TAdd(service);
                return RedirectToAction("ServiceList");
           
        }

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetById(id);
            serviceManager.TDelete(value);
            return RedirectToAction("ServiceList");
        }
    }
}
