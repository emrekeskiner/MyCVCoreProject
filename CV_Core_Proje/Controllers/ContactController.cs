using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.Abstract;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult ContactMessageList()
        {
            var values = _messageService.TGetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = _messageService.TGetById(id); 
            _messageService.TDelete(values);
            return RedirectToAction("ContactMessageList");
        }
    }
}
