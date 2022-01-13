using Account.API.Data;
using Account.API.Models;
using Account.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CheckOrCreate([FromBody] AccountModel account)
        {
            await _accountService.CheckOrCreateAsync(account.Phone);
            return Ok();
        }
        
        

    }
}
