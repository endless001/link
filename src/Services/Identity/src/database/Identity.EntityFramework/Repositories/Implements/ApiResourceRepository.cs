using System.Linq.Expressions;
using Identity.EntityFramework.DbContexts;
using Identity.Shared.Enums;
using Identity.Shared.Extensions;
using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Repositories;

public class  ApiResourceRepository<TDbContext> : IApiResourceRepository
    where TDbContext : DbContext, IIdentityConfigurationDbContext
{
    
    protected readonly TDbContext DbContext;

 
    public ApiResourceRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public bool AutoSaveChanges { get; set; } = true;
    
    public  async Task<PagedList<ApiResource>> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<ApiResource>();
        Expression<Func<ApiResource, bool>> searchCondition = x => x.Name.Contains(search);

        var apiResources = await DbContext.ApiResources.WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Name, page, pageSize).ToListAsync();

        pagedList.Data.AddRange(apiResources);
        pagedList.TotalCount = await DbContext.ApiResources.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();
        pagedList.PageSize = pageSize;

        return pagedList;
    }

    public Task<ApiResource> GetApiResourceAsync(int apiResourceId)
    {
        return DbContext.ApiResources
            .Include(x => x.UserClaims)
            .Include(x => x.Scopes)
            .Where(x => x.Id == apiResourceId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<PagedList<ApiResourceProperty>> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<ApiResourceProperty>();

        var properties = await DbContext.ApiResourceProperties.Where(x => x.ApiResource.Id == apiResourceId).PageBy(x => x.Id, page, pageSize)
            .ToListAsync();

        pagedList.Data.AddRange(properties);
        pagedList.TotalCount = await DbContext.ApiResourceProperties.Where(x => x.ApiResource.Id == apiResourceId).CountAsync();
        pagedList.PageSize = pageSize;
        
        return pagedList;
    }

    public Task<ApiResourceProperty> GetApiResourcePropertyAsync(int apiResourcePropertyId)
    {
        return DbContext.ApiResourceProperties
            .Include(x => x.ApiResource)
            .Where(x => x.Id == apiResourcePropertyId)
            .SingleOrDefaultAsync();
    }

    public async Task<int> AddApiResourcePropertyAsync(int apiResourceId, ApiResourceProperty apiResourceProperty)
    {
        var apiResource = await DbContext.ApiResources.Where(x => x.Id == apiResourceId).SingleOrDefaultAsync();

        apiResourceProperty.ApiResource = apiResource;
        await DbContext.ApiResourceProperties.AddAsync(apiResourceProperty);
        return await AutoSaveChangesAsync();
    }

    public async Task<int> DeleteApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty)
    {
        var propertyToDelete = await DbContext.ApiResourceProperties.Where(x => x.Id == apiResourceProperty.Id).SingleOrDefaultAsync();
        DbContext.ApiResourceProperties.Remove(propertyToDelete);
        return await AutoSaveChangesAsync();
    }

    public async Task<bool> CanInsertApiResourcePropertyAsync(ApiResourceProperty apiResourceProperty)
    {
        var existsWithSameName = await DbContext.ApiResourceProperties.Where(x => x.Key == apiResourceProperty.Key
            && x.ApiResource.Id == apiResourceProperty.ApiResourceId).SingleOrDefaultAsync();
        return existsWithSameName == null;
    }

    public  async Task<int> AddApiResourceAsync(ApiResource apiResource)
    {
        DbContext.ApiResources.Add(apiResource);

        await AutoSaveChangesAsync();

        return apiResource.Id;
    }

    public async Task<int> UpdateApiResourceAsync(ApiResource apiResource)
    {
        //Remove old relations
        await RemoveApiResourceClaimsAsync(apiResource);
        await RemoveApiResourceScopesAsync(apiResource);

        //Update with new data
        DbContext.ApiResources.Update(apiResource);

        return await AutoSaveChangesAsync();
    }

    public async Task<int> DeleteApiResourceAsync(ApiResource apiResource)
    {
        var resource = await DbContext.ApiResources.Where(x => x.Id == apiResource.Id).SingleOrDefaultAsync();
        DbContext.Remove(resource);
        return await AutoSaveChangesAsync();
    }

    public async Task<bool> CanInsertApiResourceAsync(ApiResource apiResource)
    {
        if (apiResource.Id == 0)
        {
            var existsWithSameName = await DbContext.ApiResources.Where(x => x.Name == apiResource.Name).SingleOrDefaultAsync();
            return existsWithSameName == null;
        }
        else
        {
            var existsWithSameName = await DbContext.ApiResources.Where(x => x.Name == apiResource.Name && x.Id != apiResource.Id).SingleOrDefaultAsync();
            return existsWithSameName == null;
        }
    }

    public async Task<PagedList<ApiResourceSecret>> GetApiSecretsAsync(int apiResourceId, int page = 1, int pageSize = 10)
    {
    
        var pagedList = new PagedList<ApiResourceSecret>();
        var apiSecrets = await DbContext.ApiSecrets.Where(x => x.ApiResource.Id == apiResourceId).PageBy(x => x.Id, page, pageSize).ToListAsync();

        pagedList.Data.AddRange(apiSecrets);
        pagedList.TotalCount = await DbContext.ApiSecrets.Where(x => x.ApiResource.Id == apiResourceId).CountAsync();
        pagedList.PageSize = pageSize;

        return pagedList;
    }

    public async Task<int> AddApiSecretAsync(int apiResourceId, ApiResourceSecret apiSecret)
    {
        apiSecret.ApiResource = await DbContext.ApiResources.Where(x => x.Id == apiResourceId).SingleOrDefaultAsync();
        await DbContext.ApiSecrets.AddAsync(apiSecret);

        return await AutoSaveChangesAsync();
    }

    public Task<ApiResourceSecret> GetApiSecretAsync(int apiSecretId)
    {
        return DbContext.ApiSecrets
            .Include(x => x.ApiResource)
            .Where(x => x.Id == apiSecretId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public  async Task<int> DeleteApiSecretAsync(ApiResourceSecret apiSecret)
    {
        var apiSecretToDelete = await DbContext.ApiSecrets.Where(x => x.Id == apiSecret.Id).SingleOrDefaultAsync();
        DbContext.ApiSecrets.Remove(apiSecretToDelete);

        return await AutoSaveChangesAsync();
    }

    public  async Task<int> SaveAllChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    
    protected virtual async Task<int> AutoSaveChangesAsync()
    {
        return AutoSaveChanges ? await DbContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
    }
    
    private async Task RemoveApiResourceClaimsAsync(ApiResource identityResource)
    {
        //Remove old api resource claims
        var apiResourceClaims = await DbContext.ApiResourceClaims.Where(x => x.ApiResource.Id == identityResource.Id).ToListAsync();
        DbContext.ApiResourceClaims.RemoveRange(apiResourceClaims);
    }
    private async Task RemoveApiResourceScopesAsync(ApiResource identityResource)
    {
        //Remove old api resource scopes
        var apiResourceScopes = await DbContext.ApiResourceScopes.Where(x => x.ApiResource.Id == identityResource.Id).ToListAsync();
        DbContext.ApiResourceScopes.RemoveRange(apiResourceScopes);
    }

    public async Task<string> GetApiResourceNameAsync(int apiResourceId)
    {
        var apiResourceName = await DbContext.ApiResources.Where(x => x.Id == apiResourceId).Select(x => x.Name).SingleOrDefaultAsync();

        return apiResourceName;
    }
}