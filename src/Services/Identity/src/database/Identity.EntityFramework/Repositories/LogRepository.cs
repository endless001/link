using System.Linq.Expressions;
using Identity.EntityFramework.DbContexts;
using Identity.EntityFramework.Entities;
using Identity.Shared.Enums;
using Identity.Shared.Extensions;
using Identity.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Repositories;

public class LogRepository<TDbContext> : ILogRepository
    where TDbContext : DbContext, ILogDbContext
{
    
    protected readonly TDbContext DbContext;

    public LogRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public async Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<Log>();
        Expression<Func<Log, bool>> searchCondition = x => x.LogEvent.Contains(search) || x.Message.Contains(search) || x.Exception.Contains(search);
        var logs = await DbContext.Logs
            .WhereIf(!string.IsNullOrEmpty(search), searchCondition)                
            .PageBy(x => x.Id, page, pageSize)
            .ToListAsync();

        pagedList.Data.AddRange(logs);
        pagedList.PageSize = pageSize;
        pagedList.TotalCount = await DbContext.Logs.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();

        return pagedList;
    }

    public async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        var logsToDelete = await DbContext.Logs.Where(x => x.TimeStamp < deleteOlderThan.Date).ToListAsync();

        if(logsToDelete.Count == 0) return;

        DbContext.Logs.RemoveRange(logsToDelete);

        await AutoSaveChangesAsync();
    }
    
    
    protected virtual async Task<int> AutoSaveChangesAsync()
    {
        return AutoSaveChanges ? await DbContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
    }

    public virtual async Task<int> SaveAllChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public bool AutoSaveChanges { get; set; } = true;
}