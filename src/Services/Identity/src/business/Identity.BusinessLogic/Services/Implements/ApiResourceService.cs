using Identity.BusinessLogic.Dtos.Configuration;
using Identity.BusinessLogic.Mappers;
using Identity.BusinessLogic.Resources;
using Identity.BusinessLogic.Shared.ExceptionHandling;
using Identity.EntityFramework.Enums;
using Identity.EntityFramework.Repositories;
using IdentityServer4.Models;

namespace Identity.BusinessLogic.Services;

public class ApiResourceService : IApiResourceService
{

    private readonly IApiResourceRepository _apiResourceRepository;
    private readonly IClientService _clientService;
    private readonly ApiResourceServiceResources _apiResourceServiceResources;
    private const string SharedSecret = "SharedSecret";

    public ApiResourceService(IApiResourceRepository apiResourceRepository, IClientService clientService, ApiResourceServiceResources apiResourceServiceResources)
    {
        _apiResourceRepository = apiResourceRepository;
        _clientService = clientService;
        _apiResourceServiceResources = apiResourceServiceResources;
    }

    public ApiSecretsDto BuildApiSecretsViewModel(ApiSecretsDto apiSecrets)
    {
        apiSecrets.HashTypes = _clientService.GetHashTypes();
        apiSecrets.TypeList = _clientService.GetSecretTypes();
        return apiSecrets;
    }

    public async Task<ApiResourcesDto> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = await _apiResourceRepository.GetApiResourcesAsync(search, page, pageSize);
        var apiResourcesDto = pagedList.ToModel();
        return apiResourcesDto;
    }

    public async Task<ApiResourcePropertiesDto> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1, int pageSize = 10)
    {
        var apiResource = await _apiResourceRepository.GetApiResourceAsync(apiResourceId);
        if (apiResource == null) throw new UserFriendlyErrorPageException(string.Format(_apiResourceServiceResources.ApiResourceDoesNotExist().Description, apiResourceId), _apiResourceServiceResources.ApiResourceDoesNotExist().Description);

        var pagedList = await _apiResourceRepository.GetApiResourcePropertiesAsync(apiResourceId, page, pageSize);
        var apiResourcePropertiesDto = pagedList.ToModel();
        apiResourcePropertiesDto.ApiResourceId = apiResourceId;
        apiResourcePropertiesDto.ApiResourceName = await _apiResourceRepository.GetApiResourceNameAsync(apiResourceId);

        return apiResourcePropertiesDto;
    }

    public async Task<ApiResourcePropertiesDto> GetApiResourcePropertyAsync(int apiResourcePropertyId)
    {
        var apiResourceProperty = await _apiResourceRepository.GetApiResourcePropertyAsync(apiResourcePropertyId);
        if (apiResourceProperty == null) throw new UserFriendlyErrorPageException(string.Format(_apiResourceServiceResources.ApiResourcePropertyDoesNotExist().Description, apiResourcePropertyId));

        var apiResourcePropertiesDto = apiResourceProperty.ToModel();
        apiResourcePropertiesDto.ApiResourceId = apiResourceProperty.ApiResourceId;
        apiResourcePropertiesDto.ApiResourceName = await _apiResourceRepository.GetApiResourceNameAsync(apiResourceProperty.ApiResourceId);

       
        return apiResourcePropertiesDto;
    }

    public async Task<int> AddApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperties)
    {
        var canInsert = await CanInsertApiResourcePropertyAsync(apiResourceProperties);
        if (!canInsert)
        {
            await BuildApiResourcePropertiesViewModelAsync(apiResourceProperties);
            throw new UserFriendlyViewException(string.Format(_apiResourceServiceResources.ApiResourcePropertyExistsValue().Description, apiResourceProperties.Key), 
                _apiResourceServiceResources.ApiResourcePropertyExistsKey().Description, apiResourceProperties);
        }

        var apiResourceProperty = apiResourceProperties.ToEntity();
        var saved = await _apiResourceRepository.AddApiResourcePropertyAsync(apiResourceProperties.ApiResourceId, apiResourceProperty);

        return saved;
    }

    public async Task<int> DeleteApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty)
    {
        var propertyEntity = apiResourceProperty.ToEntity();

        var deleted = await _apiResourceRepository.DeleteApiResourcePropertyAsync(propertyEntity);

        return deleted;
    }

    public Task<bool> CanInsertApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty)
    {
        var resource = apiResourceProperty.ToEntity();

        return _apiResourceRepository.CanInsertApiResourcePropertyAsync(resource);
    }

    public async Task<ApiResourceDto> GetApiResourceAsync(int apiResourceId)
    {
        var apiResource = await _apiResourceRepository.GetApiResourceAsync(apiResourceId);
        if (apiResource == null) throw new UserFriendlyErrorPageException(_apiResourceServiceResources.ApiResourceDoesNotExist().Description, _apiResourceServiceResources.ApiResourceDoesNotExist().Description);
        var apiResourceDto = apiResource.ToModel();
        return apiResourceDto;
    }

    public async Task<int> AddApiResourceAsync(ApiResourceDto apiResource)
    {
        var canInsert = await CanInsertApiResourceAsync(apiResource);
        if (!canInsert)
        {
            throw new UserFriendlyViewException(string.Format(_apiResourceServiceResources.ApiResourceExistsValue().Description, apiResource.Name), _apiResourceServiceResources.ApiResourceExistsKey().Description, apiResource);
        }

        var resource = apiResource.ToEntity();

        var added = await _apiResourceRepository.AddApiResourceAsync(resource);
        return added;
    }

    public async Task<int> UpdateApiResourceAsync(ApiResourceDto apiResource)
    {
        var canInsert = await CanInsertApiResourceAsync(apiResource);
        if (!canInsert)
        {
            throw new UserFriendlyViewException(string.Format(_apiResourceServiceResources.ApiResourceExistsValue().Description, apiResource.Name), _apiResourceServiceResources.ApiResourceExistsKey().Description, apiResource);
        }

        var resource = apiResource.ToEntity();
        var updated = await _apiResourceRepository.UpdateApiResourceAsync(resource);

        return updated;

    }

    public async Task<int> DeleteApiResourceAsync(ApiResourceDto apiResource)
    {
        var resource = apiResource.ToEntity();
        var deleted = await _apiResourceRepository.DeleteApiResourceAsync(resource);
        return deleted;
    }

    public  Task<bool> CanInsertApiResourceAsync(ApiResourceDto apiResource)
    {
        var resource = apiResource.ToEntity();
        return  _apiResourceRepository.CanInsertApiResourceAsync(resource);
    }

    public async Task<ApiSecretsDto> GetApiSecretsAsync(int apiResourceId, int page = 1, int pageSize = 10)
    {
        var apiResource = await _apiResourceRepository.GetApiResourceAsync(apiResourceId);
        if (apiResource == null) throw new UserFriendlyErrorPageException(string.Format(_apiResourceServiceResources.ApiResourceDoesNotExist().Description, apiResourceId),
            _apiResourceServiceResources.ApiResourceDoesNotExist().Description);

        var pagedList = await _apiResourceRepository.GetApiSecretsAsync(apiResourceId, page, pageSize);

        var apiSecretsDto = pagedList.ToModel();
        apiSecretsDto.ApiResourceId = apiResourceId;
        apiSecretsDto.ApiResourceName = await _apiResourceRepository.GetApiResourceNameAsync(apiResourceId);

        // remove secret value from dto
        apiSecretsDto.ApiSecrets.ForEach(x => x.Value = null);

        
        return apiSecretsDto;
    }

    public async  Task<int> AddApiSecretAsync(ApiSecretsDto apiSecret)
    {
        HashApiSharedSecret(apiSecret);

        var secret = apiSecret.ToEntity();

        var added = await _apiResourceRepository.AddApiSecretAsync(apiSecret.ApiResourceId, secret);

       
        return added;
    }

    public async Task<ApiSecretsDto> GetApiSecretAsync(int apiSecretId)
    {
        var apiSecret = await _apiResourceRepository.GetApiSecretAsync(apiSecretId);
        if (apiSecret == null) throw new UserFriendlyErrorPageException(string.Format(_apiResourceServiceResources.ApiSecretDoesNotExist().Description, apiSecretId), _apiResourceServiceResources.ApiSecretDoesNotExist().Description);
        var apiSecretsDto = apiSecret.ToModel();

        // remove secret value for dto
        apiSecretsDto.Value = null;

        return apiSecretsDto;
    }

    public async Task<int> DeleteApiSecretAsync(ApiSecretsDto apiSecret)
    {
        var secret = apiSecret.ToEntity();
        var deleted = await _apiResourceRepository.DeleteApiSecretAsync(secret);
        return deleted;
    }

    public Task<string> GetApiResourceNameAsync(int apiResourceId)
    {
        return _apiResourceRepository.GetApiResourceNameAsync(apiResourceId);
    }

    private async Task BuildApiResourcePropertiesViewModelAsync(ApiResourcePropertiesDto apiResourceProperties)
    {
        var apiResourcePropertiesDto = await GetApiResourcePropertiesAsync(apiResourceProperties.ApiResourceId);
        apiResourceProperties.ApiResourceProperties.AddRange(apiResourcePropertiesDto.ApiResourceProperties);
        apiResourceProperties.TotalCount = apiResourcePropertiesDto.TotalCount;
    }
    private void HashApiSharedSecret(ApiSecretsDto apiSecret)
    {
        if (apiSecret.Type != SharedSecret) return;

        if (apiSecret.HashTypeEnum == HashType.Sha256)
        {
            apiSecret.Value = apiSecret.Value.Sha256();
        }
        else if (apiSecret.HashTypeEnum == HashType.Sha512)
        {
            apiSecret.Value = apiSecret.Value.Sha512();
        }
    }
}