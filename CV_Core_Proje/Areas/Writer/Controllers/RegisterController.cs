using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.EntityLayer.Concrete;
using MyCVCore.PresentationLayer.Areas.Writer.Models;

namespace MyCVCore.PresentationLayer.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    SurName = p.SurName,
                    Email = p.Mail,
                    UserName = p.UserName

                };
                if (p.ConfirmPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(w, p.Password);
                
                
                if (result.Succeeded)
                {
                    return RedirectToAction("UserLogin", "Login", new {Areas="Writer"});
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
               }
            }
            return View();
        }
    }
}


