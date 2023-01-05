using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ConsoleApp1.Models;
using ConsoleApp1.Repository;
using ConsoleApp1.Service;

namespace ConsoleApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration, IMessageRepository messageRepository, IUserService userService, IEmailService emailService)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<ViewResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com"},
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", "John")
                }
            };

            await _emailService.SendTestEmail(options);
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
