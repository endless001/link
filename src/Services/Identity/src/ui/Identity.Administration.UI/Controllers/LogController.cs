using Identity.BusinessLogic.Dtos.Log;
using Identity.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Administration.UI.Controllers;


public class LogController :BaseController
{
    private readonly ILogService _logService;
    
    
    public LogController(ILogService logService,ILogger<LogController> logger) : base(logger)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> ErrorsLog(int? page, string search)
    {
        ViewBag.Search = search;
        var logs = await _logService.GetLogsAsync(search, page ?? 1);

        return View(logs);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteLogs(LogsDto log)
    {
        if (!ModelState.IsValid)
        {
            return View(nameof(ErrorsLog), log);
        }
            
        await _logService.DeleteLogsOlderThanAsync(log.DeleteOlderThan.Value);

        return RedirectToAction(nameof(ErrorsLog));
    }
}