using Identity.BusinessLogic.Dtos.Configuration;

namespace Identity.BusinessLogic.Services;

public class ApiResourceService : IApiResourceService
{
  public ApiSecretsDto BuildApiSecretsViewModel(ApiSecretsDto apiSecrets)
  {
    throw new NotImplementedException();
  }

  public Task<ApiResourcesDto> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10)
  {
    throw new NotImplementedException();
  }

  public Task<ApiResourcePropertiesDto> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1,
    int pageSize = 10)
  {
    throw new NotImplementedException();
  }

  public Task<ApiResourcePropertiesDto> GetApiResourcePropertyAsync(int apiResourcePropertyId)
  {
    throw new NotImplementedException();
  }

  public Task<int> AddApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperties)
  {
    throw new NotImplementedException();
  }

  public Task<int> DeleteApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty)
  {
    throw new NotImplementedException();
  }

  public Task<bool> CanInsertApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty)
  {
    throw new NotImplementedException();
  }

  public Task<ApiResourceDto> GetApiResourceAsync(int apiResourceId)
  {
    throw new NotImplementedException();
  }

  public Task<int> AddApiResourceAsync(ApiResourceDto apiResource)
  {
    throw new NotImplementedException();
  }

  public Task<int> UpdateApiResourceAsync(ApiResourceDto apiResource)
  {
    throw new NotImplementedException();
  }

  public Task<int> DeleteApiResourceAsync(ApiResourceDto apiResource)
  {
    throw new NotImplementedException();
  }

  public Task<bool> CanInsertApiResourceAsync(ApiResourceDto apiResource)
  {
    throw new NotImplementedException();
  }

  public Task<ApiSecretsDto> GetApiSecretsAsync(int apiResourceId, int page = 1, int pageSize = 10)
  {
    throw new NotImplementedException();
  }

  public Task<int> AddApiSecretAsync(ApiSecretsDto apiSecret)
  {
    throw new NotImplementedException();
  }

  public Task<ApiSecretsDto> GetApiSecretAsync(int apiSecretId)
  {
    throw new NotImplementedException();
  }

  public Task<int> DeleteApiSecretAsync(ApiSecretsDto apiSecret)
  {
    throw new NotImplementedException();
  }

  public Task<string> GetApiResourceNameAsync(int apiResourceId)
  {
    throw new NotImplementedException();
  }
}