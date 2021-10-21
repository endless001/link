using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class DownloadController : Controller
    {
         
        private readonly ILogger<DownloadController> _logger;

        public DownloadController(ILogger<DownloadController> logger)
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