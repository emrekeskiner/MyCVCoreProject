using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;

namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{
    public class PortfolioDashboard : ViewComponent
    {
        PortfolioManager portfolioManager= new PortfolioManager(new EfPortfolioDal());
    public IViewComponentResult Invoke()
    {
        var values = portfolioManager.TGetList();
        return View(values);
    }
    
    }
}
