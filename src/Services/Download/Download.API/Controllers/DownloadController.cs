using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Download.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DownloadController : ControllerBase
    {
        private readonly ILogger<DownloadController> _logger;
        public DownloadController(ILogger<DownloadController> logger)
        {
            _logger = logger;
        }

        public IActionResult Get()
        {
            return Content("1");
        }
    }
}
