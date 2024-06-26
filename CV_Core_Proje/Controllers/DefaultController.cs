﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.EntityFramework;
using Newtonsoft.Json;

namespace MyCVCore.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {

            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {

            return PartialView();
        }
        //[HttpGet]
        //public PartialViewResult SendMessage()
        //{

        //    return PartialView();
        //}
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            var values = JsonConvert.SerializeObject(message);
            if (values != null)
            {
             message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        message.Status = true;
                        messageManager.TAdd(message);
            
                        return Json(message);
            }
            return Json(null);

        }
    }
}
