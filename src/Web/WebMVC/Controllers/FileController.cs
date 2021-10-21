using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class FileController : Controller
    {
        
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
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