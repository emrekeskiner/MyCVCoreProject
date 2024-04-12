using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult AdminSocialMediaList()
        {
            var values = _socialMediaService.TGetList();
            return View(values);
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return RedirectToAction("AdminSocialMediaList");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return RedirectToAction("AdminSocialMediaList");
        }
        
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TAdd(socialMedia);
            return RedirectToAction("AdminSocialMediaList");
        }

        public IActionResult StatusChange(int id)
        {
            var values = _socialMediaService.TGetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
           
            _socialMediaService.TUpdate(values);
            return RedirectToAction("AdminSocialMediaList");
        }
    }
}
