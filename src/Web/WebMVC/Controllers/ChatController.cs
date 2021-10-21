using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class ChatController : Controller
    {
        
        private readonly ILogger<ChatController> _logger;

        public ChatController(ILogger<ChatController> logger)
        {
            _logger = logger;
        }

        // GET
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}