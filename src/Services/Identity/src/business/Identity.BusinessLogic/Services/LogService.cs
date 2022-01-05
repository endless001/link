using Identity.BusinessLogic.Dtos.Log;

namespace Identity.BusinessLogic.Services;

public class LogService:ILogService
{
    public Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        throw new NotImplementedException();
    }
}