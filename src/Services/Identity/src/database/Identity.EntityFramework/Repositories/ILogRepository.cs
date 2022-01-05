using Identity.EntityFramework.Entities;
using Identity.Shared.Models;

namespace Identity.EntityFramework.Repositories;

public interface ILogRepository
{
    Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10);

    Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);

    bool AutoSaveChanges { get; set; }
}