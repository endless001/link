using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Identity.Administration.UI.Models;
using Identity.Shared.Configuration.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;

namespace Identity.Administration.UI.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
        : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );
        return LocalRedirect(returnUrl);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SelectTheme(string theme, string returnUrl)
    {
        Response.Cookies.Append(
            ThemeHelpers.CookieThemeKey,
            theme,
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return LocalRedirect(returnUrl);
    }
    
    public IActionResult Error()
    {
        // Get the details of the exception that occurred
        var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionFeature == null) return View();
        // Get which route the exception occurred at
        string routeWhereExceptionOccurred = exceptionFeature.Path;
        // Get the exception that occurred
        Exception exceptionThatOccurred = exceptionFeature.Error;
        // Log the exception
        _logger.LogError(exceptionThatOccurred, $"Exception at route {routeWhereExceptionOccurred}");

        return View();
    }
}