using Identity.BusinessLogic.Dtos.Configuration;
using Identity.BusinessLogic.Helpers;
using Identity.BusinessLogic.Mappers;
using Identity.BusinessLogic.Resources;
using Identity.BusinessLogic.Shared.ExceptionHandling;
using Identity.EntityFramework.Repositories;
using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;

namespace Identity.BusinessLogic.Services;

public class ApiScopeService : IApiScopeService
{
    private readonly IApiScopeRepository _apiScopeRepository;
    private readonly IApiScopeServiceResources _apiScopeServiceResources;

    public ApiScopeService(IApiScopeServiceResources apiScopeServiceResources, IApiScopeRepository apiScopeRepository)
    {
        _apiScopeRepository = apiScopeRepository;
        _apiScopeServiceResources = apiScopeServiceResources;

    }
    public ApiScopeDto BuildApiScopeViewModel(ApiScopeDto apiScope)
    {
        ComboBoxHelpers.PopulateValuesToList(apiScope.UserClaimsItems, apiScope.UserClaims);

        return apiScope;
    }

    public async Task<ApiScopesDto> GetApiScopesAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = await _apiScopeRepository.GetApiScopesAsync(search, page, pageSize);

        var apiScopesDto = pagedList.ToModel();
         

        return apiScopesDto;
    }

    public async Task<ICollection<string>> GetApiScopesNameAsync(string scope, int limit = 0)
    {
        var scopes = await _apiScopeRepository.GetApiScopesNameAsync(scope, limit);

        return scopes;
    }

    public async Task<ApiScopeDto> GetApiScopeAsync(int apiScopeId)
    {
        var apiScope = await _apiScopeRepository.GetApiScopeAsync(apiScopeId);
        if (apiScope == null) throw new UserFriendlyErrorPageException(string.Format(_apiScopeServiceResources.ApiScopeDoesNotExist().Description, apiScopeId),
            _apiScopeServiceResources.ApiScopeDoesNotExist().Description);

        var apiScopeDto = apiScope.ToModel();

        return apiScopeDto;
    }

    public async Task<int> AddApiScopeAsync(ApiScopeDto apiScope)
    {
        var canInsert = await CanInsertApiScopeAsync(apiScope);
        if (!canInsert)
        {
            throw new UserFriendlyViewException(string.Format(_apiScopeServiceResources.ApiScopeExistsValue().Description, apiScope.Name),
                _apiScopeServiceResources.ApiScopeExistsKey().Description, apiScope);
        }

        var scope = apiScope.ToEntity();

        var added = await _apiScopeRepository.AddApiScopeAsync(scope);
         
        return added;
    }

    public async Task<int> UpdateApiScopeAsync(ApiScopeDto apiScope)
    {

        var canInsert = await CanInsertApiScopeAsync(apiScope);
        if (!canInsert)
        {
            throw new UserFriendlyViewException(string.Format(_apiScopeServiceResources.ApiScopeExistsValue().Description, apiScope.Name), _apiScopeServiceResources.ApiScopeExistsKey().Description, apiScope);
        }

        var scope = apiScope.ToEntity();

        var updated = await _apiScopeRepository.UpdateApiScopeAsync(scope);

        return updated;
    }

    public async Task<int> DeleteApiScopeAsync(ApiScopeDto apiScope)
    {
        var scope = apiScope.ToEntity();
        var deleted = await _apiScopeRepository.DeleteApiScopeAsync(scope);
        return deleted;
    }

    public async Task<bool> CanInsertApiScopeAsync(ApiScopeDto apiScopes)
    {
        var apiScope = apiScopes.ToEntity();

        return await _apiScopeRepository.CanInsertApiScopeAsync(apiScope);
    }

    public async Task<ApiScopePropertiesDto> GetApiScopePropertiesAsync(int apiScopeId, int page = 1, int pageSize = 10)
    {
        var apiScope = await _apiScopeRepository.GetApiScopeAsync(apiScopeId);
        if (apiScope == null)
            throw new UserFriendlyErrorPageException(string.Format(_apiScopeServiceResources.ApiScopeDoesNotExist().Description, apiScopeId), _apiScopeServiceResources.ApiScopeDoesNotExist().Description);

        PagedList<ApiScopeProperty> pagedList = await _apiScopeRepository.GetApiScopePropertiesAsync(apiScopeId, page, pageSize);
        var apiScopePropertiesDto = pagedList.ToModel();
        apiScopePropertiesDto.ApiScopeId = apiScopeId;
        apiScopePropertiesDto.ApiScopeName = await _apiScopeRepository.GetApiScopeNameAsync(apiScopeId);
        
        return apiScopePropertiesDto;
    }

    public async Task<int> AddApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperties)
    {
        var canInsert = await CanInsertApiScopePropertyAsync(apiScopeProperties);
        if (!canInsert)
        {
            await BuildApiScopePropertiesViewModelAsync(apiScopeProperties);
            throw new UserFriendlyViewException(string.Format(_apiScopeServiceResources.ApiScopePropertyExistsValue().Description, apiScopeProperties.Key), _apiScopeServiceResources.ApiScopePropertyExistsKey().Description, apiScopeProperties);
        }

        var apiScopeProperty = apiScopeProperties.ToEntity();

        var saved = await _apiScopeRepository.AddApiScopePropertyAsync(apiScopeProperties.ApiScopeId, apiScopeProperty);
        
        return saved;
    }

    public async Task<int> DeleteApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperty)
    {
        var propertyEntity = apiScopeProperty.ToEntity();

        var deleted = await _apiScopeRepository.DeleteApiScopePropertyAsync(propertyEntity);
 
        return deleted;
    }

    public async Task<ApiScopePropertiesDto> GetApiScopePropertyAsync(int apiScopePropertyId)
    {
        var apiScopeProperty = await _apiScopeRepository.GetApiScopePropertyAsync(apiScopePropertyId);
        if (apiScopeProperty == null) throw new UserFriendlyErrorPageException(string.Format(_apiScopeServiceResources.ApiScopePropertyDoesNotExist().Description, apiScopePropertyId));

        var apiScopePropertiesDto = apiScopeProperty.ToModel();
        apiScopePropertiesDto.ApiScopeId = apiScopeProperty.ScopeId;
        apiScopePropertiesDto.ApiScopeName = await _apiScopeRepository.GetApiScopeNameAsync(apiScopeProperty.ScopeId);

        return apiScopePropertiesDto;
    }

    public async Task<bool> CanInsertApiScopePropertyAsync(ApiScopePropertiesDto apiResourceProperty)
    {
        var resource = apiResourceProperty.ToEntity();

        return await _apiScopeRepository.CanInsertApiScopePropertyAsync(resource);
    }
    private async Task BuildApiScopePropertiesViewModelAsync(ApiScopePropertiesDto apiScopeProperties)
    {
        var apiResourcePropertiesDto = await GetApiScopePropertiesAsync(apiScopeProperties.ApiScopeId);
        apiScopeProperties.ApiScopeProperties.AddRange(apiResourcePropertiesDto.ApiScopeProperties);
        apiScopeProperties.TotalCount = apiResourcePropertiesDto.TotalCount;
    }
}