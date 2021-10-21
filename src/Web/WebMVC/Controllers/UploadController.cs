using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class UploadController : Controller
    {
        
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
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