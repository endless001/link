using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class ContactController : Controller
    {
        
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
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