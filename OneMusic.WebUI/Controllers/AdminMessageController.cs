using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public AdminMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var value = _messageService.TGetList();
            return View(value);
        }

        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult OkuMessage(int id)
        {
            var mesaj = _messageService.TGetById(id);
            return View(mesaj);
        }
    }
}
