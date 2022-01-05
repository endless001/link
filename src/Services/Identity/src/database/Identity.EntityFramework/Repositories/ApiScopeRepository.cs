﻿using System.Linq.Expressions;
using Identity.EntityFramework.DbContexts;
using Identity.Shared.Enums;
using Identity.Shared.Extensions;
using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Repositories;

public class ApiScopeRepository<TDbContext> : IApiScopeRepository
    where TDbContext : DbContext, IIdentityConfigurationDbContext
{

    protected readonly TDbContext DbContext;

    public ApiScopeRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public bool AutoSaveChanges { get; set; } = true;

    public async Task<PagedList<ApiScope>> GetApiScopesAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<ApiScope>();
        Expression<Func<ApiScope, bool>> searchCondition = x => x.Name.Contains(search);

        var filteredApiScopes = DbContext.ApiScopes
            .WhereIf(!string.IsNullOrEmpty(search), searchCondition);

        var apiScopes = await filteredApiScopes
            .PageBy(x => x.Name, page, pageSize).ToListAsync();

        pagedList.Data.AddRange(apiScopes);
        pagedList.TotalCount = await filteredApiScopes.CountAsync();
        pagedList.PageSize = pageSize;

        return pagedList;
    }

    public Task<ApiScope> GetApiScopeAsync(int apiScopeId)
    {
        return DbContext.ApiScopes
            .Include(x => x.UserClaims)
            .Where(x => x.Id == apiScopeId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<int> AddApiScopeAsync(ApiScope apiScope)
    {
        await DbContext.ApiScopes.AddAsync(apiScope);

        await AutoSaveChangesAsync();

        return apiScope.Id;
    }

    public async Task<int> UpdateApiScopeAsync(ApiScope apiScope)
    {
        await RemoveApiScopeClaimsAsync(apiScope);

        //Update with new data
        DbContext.ApiScopes.Update(apiScope);

        return await AutoSaveChangesAsync();
    }

    public async Task<int> DeleteApiScopeAsync(ApiScope apiScope)
    {
        var apiScopeToDelete = await DbContext.ApiScopes.Where(x => x.Id == apiScope.Id).SingleOrDefaultAsync();
        DbContext.ApiScopes.Remove(apiScopeToDelete);

        return await AutoSaveChangesAsync();
    }

    public  async Task<bool> CanInsertApiScopeAsync(ApiScope apiScope)
    {
        if (apiScope.Id == 0)
        {
            var existsWithSameName = await DbContext.ApiScopes.Where(x => x.Name == apiScope.Name).SingleOrDefaultAsync();
            return existsWithSameName == null;
        }
        else
        {
            var existsWithSameName = await DbContext.ApiScopes.Where(x => x.Name == apiScope.Name && x.Id != apiScope.Id).SingleOrDefaultAsync();
            return existsWithSameName == null;
        }
    }

    public  async Task<ICollection<string>> GetApiScopesNameAsync(string scope, int limit = 0)
    {
        var apiScopes = await DbContext.ApiScopes
            .WhereIf(!string.IsNullOrEmpty(scope), x => x.Name.Contains(scope))
            .TakeIf(x => x.Id, limit > 0, limit)
            .Select(x => x.Name).ToListAsync();
            
        return apiScopes;
    }

    public async Task<PagedList<ApiScopeProperty>> GetApiScopePropertiesAsync(int apiScopeId, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<ApiScopeProperty>();

        var apiScopeProperties = DbContext.ApiScopeProperties.Where(x => x.Scope.Id == apiScopeId);

        var properties = await apiScopeProperties.PageBy(x => x.Id, page, pageSize)
            .ToListAsync();

        pagedList.Data.AddRange(properties);
        pagedList.TotalCount = await apiScopeProperties.CountAsync();
        pagedList.PageSize = pageSize;

        return pagedList;
    }

    public Task<ApiScopeProperty> GetApiScopePropertyAsync(int apiScopePropertyId)
    { 
        return DbContext.ApiScopeProperties
            .Include(x => x.Scope)
            .Where(x => x.Id == apiScopePropertyId)
            .SingleOrDefaultAsync();
    }

    public async Task<int> AddApiScopePropertyAsync(int apiScopeId, ApiScopeProperty apiScopeProperty)
    {
        var apiScope = await DbContext.ApiScopes.Where(x => x.Id == apiScopeId).SingleOrDefaultAsync();

        apiScopeProperty.Scope = apiScope;
        await DbContext.ApiScopeProperties.AddAsync(apiScopeProperty);

        return await AutoSaveChangesAsync();
    }

    public async Task<bool> CanInsertApiScopePropertyAsync(ApiScopeProperty apiScopeProperty)
    {
        var existsWithSameName = await DbContext.ApiScopeProperties.Where(x => x.Key == apiScopeProperty.Key
                                                                               && x.Scope.Id == apiScopeProperty.Scope.Id).SingleOrDefaultAsync();
        return existsWithSameName == null;
    }

    public async Task<int> DeleteApiScopePropertyAsync(ApiScopeProperty apiScopeProperty)
    {
        var propertyToDelete = await DbContext.ApiScopeProperties.Where(x => x.Id == apiScopeProperty.Id).SingleOrDefaultAsync();

        DbContext.ApiScopeProperties.Remove(propertyToDelete);

        return await AutoSaveChangesAsync();
    }

    public  async Task<string> GetApiScopeNameAsync(int apiScopeId)
    {
        var apiScopeName = await DbContext.ApiScopes.Where(x => x.Id == apiScopeId).Select(x => x.Name).SingleOrDefaultAsync();

        return apiScopeName;
    }

    public async Task<int> SaveAllChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
    
    protected virtual async Task<int> AutoSaveChangesAsync()
    {
        return AutoSaveChanges ? await DbContext.SaveChangesAsync() : (int) SavedStatus.WillBeSavedExplicitly;
    }
    
    private async Task RemoveApiScopeClaimsAsync(ApiScope apiScope)
    {
        //Remove old api scope claims
        var apiScopeClaims = await DbContext.ApiScopeClaims.Where(x => x.Scope.Id == apiScope.Id).ToListAsync();
        DbContext.ApiScopeClaims.RemoveRange(apiScopeClaims);
    }

}