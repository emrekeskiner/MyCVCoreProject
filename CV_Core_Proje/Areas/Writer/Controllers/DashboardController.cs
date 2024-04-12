
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.DataAccessLayer.Context;
using MyCVCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> UserDashboard()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.kullaniciAdiSoyadi = values.Name + " " + values.SurName;

            //Weather APi
            string api = "87f57a9e1d6bb35070ed945380f0e3a7";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=salihli&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v6 = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            //Kur Api
            DateTime tarih = DateTime.Now;
            string connectionKur = "https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.EUR.A-TP.DK.CHF.A-TP.DK.GBP.A-TP.DK.JPY.A&startDate="+ tarih.ToString("dd-MM-yyyy")+ "&endDate="+ tarih.ToString("dd-MM-yyyy") + "&type=xml&key=M5lnbvjJb3";
            XDocument document1 = XDocument.Load(connectionKur);
            ViewBag.kurDolar = document1.Descendants("TP_DK_USD_A").ElementAt(0).Value;
            ViewBag.kurEuro = document1.Descendants("TP_DK_EUR_A").ElementAt(0).Value;

            //statistics
            CvContext c = new CvContext();
            ViewBag.v1 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
/*
 http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=14ad2aba611dbef9c504b82a127794c5
 */