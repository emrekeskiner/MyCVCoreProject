using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.EntityFramework;
using MyCVCore.EntityLayer.Concrete;


namespace MyCVCore.PresentationLayer.ViewComponents.Dashboard
{
    public class MessageListDashboard : ViewComponent
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterUser> _userManager;

        public MessageListDashboard(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _writerMessageService.GetListReceiverMessage(values.Email).OrderByDescending(x => x.WriterMessageId).Take(4).ToList();

            return View(messages);
        }
    }
}
