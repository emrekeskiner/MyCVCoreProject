using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.Context;
using MyCVCore.EntityLayer.Concrete;

namespace MyCVCore.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/Message/")]
    public class MessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService; 
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        [Route("UserReceiverMessage")]
        public async Task<IActionResult> UserReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList =  _writerMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }

        [HttpGet]
        [Route("")]
        [Route("UserSendMessage")]
        public async Task<IActionResult> UserSendMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListSendMessage(p);
            return View(messageList);
        }

        [HttpGet]
        [Route("")]
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values = _writerMessageService.TGetById(id);
            return View(values);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            writerMessage.Sender = values.Email;
            writerMessage.SenderName = values.Name + " " + values.SurName;
            writerMessage.ReceiverName = "test";
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            CvContext context = new CvContext();
            var usernameSurname= context.Users.Where(x =>x.Email==writerMessage.Receiver).Select(y => y.Name+" "+y.SurName).FirstOrDefault();
            writerMessage.ReceiverName = usernameSurname;
            _writerMessageService.TAdd(writerMessage);
            return RedirectToAction("UserReceiverMessage","Message");
        }
    }
}
