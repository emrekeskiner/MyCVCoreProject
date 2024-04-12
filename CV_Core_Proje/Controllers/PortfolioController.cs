using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.BusinessLayer.ValidationRules;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager= new PortfolioManager(new EfPortfolioDal());
        public IActionResult PortfolioList()
        {
           
            var values = portfolioManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            
            var values = portfolioManager.TGetById(id);

            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
           
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
           
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {

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
