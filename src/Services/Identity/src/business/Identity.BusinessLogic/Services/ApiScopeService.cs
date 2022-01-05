using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Services;

public class ApiScopeService:IApiScopeService
{
    public ApiScopeDto BuildApiScopeViewModel(ApiScopeDto apiScope)
    {
        throw new NotImplementedException();
    }

    public Task<ApiScopesDto> GetApiScopesAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<string>> GetApiScopesNameAsync(string scope, int limit = 0)
    {
        throw new NotImplementedException();
    }

    public Task<ApiScopeDto> GetApiScopeAsync(int apiScopeId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddApiScopeAsync(ApiScopeDto apiScope)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateApiScopeAsync(ApiScopeDto apiScope)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteApiScopeAsync(ApiScopeDto apiScope)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertApiScopeAsync(ApiScopeDto apiScopes)
    {
        throw new NotImplementedException();
    }

    public Task<ApiScopePropertiesDto> GetApiScopePropertiesAsync(int apiScopeId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperties)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperty)
    {
        throw new NotImplementedException();
    }

    public Task<ApiScopePropertiesDto> GetApiScopePropertyAsync(int apiScopePropertyId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertApiScopePropertyAsync(ApiScopePropertiesDto apiResourceProperty)
    {
        throw new NotImplementedException();
    }
}