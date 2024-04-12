using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.DataAccessLayer.Context;
using MyCVCore.EntityLayer.Concrete;

namespace MyCVCore.PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {

        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterUser> _userManager;

        public AdminMessageController(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AdminReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> AdminSenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListSendMessage(p);
            return View(messageList);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageService.TGetById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminSendMessage(WriterMessage writerMessage)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            writerMessage.Sender = values.Email;
            writerMessage.SenderName = values.Name +" "+values.SurName;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            CvContext context = new CvContext();
            var usernameSurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            writerMessage.ReceiverName = usernameSurname;
            _writerMessageService.TAdd(writerMessage);
            return RedirectToAction("AdminReceiverMessage", "AdminMessage");
        }
    }
}

