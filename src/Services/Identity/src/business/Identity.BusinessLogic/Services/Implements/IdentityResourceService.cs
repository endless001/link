using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Services;

public class IdentityResourceService:IIdentityResourceService
{
    public Task<IdentityResourcesDto> GetIdentityResourcesAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResourceDto> GetIdentityResourceAsync(int identityResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertIdentityResourceAsync(IdentityResourceDto identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddIdentityResourceAsync(IdentityResourceDto identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateIdentityResourceAsync(IdentityResourceDto identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteIdentityResourceAsync(IdentityResourceDto identityResource)
    {
        throw new NotImplementedException();
    }

    public IdentityResourceDto BuildIdentityResourceViewModel(IdentityResourceDto identityResource)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResourcePropertiesDto> GetIdentityResourcePropertiesAsync(int identityResourceId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResourcePropertiesDto> GetIdentityResourcePropertyAsync(int identityResourcePropertyId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourceProperties)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourceProperty)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourcePropertiesDto)
    {
        throw new NotImplementedException();
    }
}