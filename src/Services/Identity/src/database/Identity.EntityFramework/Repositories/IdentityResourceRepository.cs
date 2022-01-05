using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Repositories;

public class IdentityResourceRepository<TDbContext> : IIdentityResourceRepository
    where TDbContext : DbContext, IAdminConfigurationDbContext
{
    public Task<PagedList<IdentityResource>> GetIdentityResourcesAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResource> GetIdentityResourceAsync(int identityResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertIdentityResourceAsync(IdentityResource identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddIdentityResourceAsync(IdentityResource identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateIdentityResourceAsync(IdentityResource identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteIdentityResourceAsync(IdentityResource identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertIdentityResourcePropertyAsync(IdentityResourceProperty identityResourceProperty)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<IdentityResourceProperty>> GetIdentityResourcePropertiesAsync(int identityResourceId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResourceProperty> GetIdentityResourcePropertyAsync(int identityResourcePropertyId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddIdentityResourcePropertyAsync(int identityResourceId, IdentityResourceProperty identityResourceProperty)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteIdentityResourcePropertyAsync(IdentityResourceProperty identityResourceProperty)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAllChangesAsync()
    {
        throw new NotImplementedException();
    }

    public bool AutoSaveChanges { get; set; }
}