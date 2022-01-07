using Identity.Administration.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Administration.UI.Controllers;

public class AccountController : BaseController
{
    
    public AccountController(ILogger<AccountController> logger) : base(logger)
    { }

    // GET
    public IActionResult AccessDenied()
    {
        return View();
    }
    
    public IActionResult Logout()
    {
        return new SignOutResult(new List<string> { AuthenticationConsts.SignInScheme, AuthenticationConsts.OidcAuthenticationScheme });
    }
}