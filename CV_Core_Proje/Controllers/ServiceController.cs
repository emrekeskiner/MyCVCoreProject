using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult ServiceList()
        {

            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {

            var values = serviceManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
       
                serviceManager.TUpdate(service);

                return RedirectToAction("ServiceList");
         

        }

        [HttpGet]
        public IActionResult AddService()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
           
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
