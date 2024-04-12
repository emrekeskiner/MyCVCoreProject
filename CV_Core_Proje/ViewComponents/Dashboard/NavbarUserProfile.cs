using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.EntityLayer.Concrete;

namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{
    public class NavbarUserProfile : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarUserProfile(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity?.Name);
            ViewBag.userImagesUrl = values.ImageUrl;
            ViewBag.userName = values.Name+" "+values.SurName;

            return View();
        }
    }
}
