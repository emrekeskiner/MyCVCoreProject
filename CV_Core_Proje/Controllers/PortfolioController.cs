using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager= new PortfolioManager(new EfPortfolioDal());
        public IActionResult PortfolioList()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Proje Listesi";
            ViewBag.sayfa = "Projeler";
            ViewBag.url = "/Portfolio/PortfolioList";
            //---------------------------------

            var values = portfolioManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Proje Güncelle";
            ViewBag.sayfa = "Projeler";
            ViewBag.url = "/Portfolio/PortfolioList";
            //---------------------------------

            var values = portfolioManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Proje Güncelle";
            ViewBag.sayfa = "Projeler";
            ViewBag.url = "/Portfolio/PortfolioList";
            //---------------------------------
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);
            if (result.IsValid)
            {
             portfolioManager.TUpdate(portfolio);

             return RedirectToAction("PortfolioList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Proje Ekle";
            ViewBag.sayfa = "Projeler";
            ViewBag.url = "/Portfolio/PortfolioList";
            //---------------------------------
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            //-------Sayfa Başlık işlemleri----
            ViewBag.baslik = "Proje Ekle";
            ViewBag.sayfa = "Projeler";
            ViewBag.url = "/Portfolio/PortfolioList";
            //---------------------------------


            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if(results.IsValid) 
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("PortfolioList");
            }else 
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }          
            }
            return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetById(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("PortfolioList");
        }
    }

}
