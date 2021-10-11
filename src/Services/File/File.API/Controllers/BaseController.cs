using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Controllers
{
    public class BaseController : Controller
    {
        protected int AccountId
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
            }
        }
    }
}
