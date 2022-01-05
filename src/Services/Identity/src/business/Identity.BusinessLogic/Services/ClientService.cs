using Identity.BusinessLogic.Dtos.Configuration;
using Identity.BusinessLogic.Shared.Dtos;

namespace Identity.BusinessLogic.Services;

public class ClientService:IClientService
{
    public ClientDto BuildClientViewModel(ClientDto client = null)
    {
        throw new NotImplementedException();
    }

    public ClientSecretsDto BuildClientSecretsViewModel(ClientSecretsDto clientSecrets)
    {
        throw new NotImplementedException();
    }

    public ClientCloneDto BuildClientCloneViewModel(int id, ClientDto clientDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientAsync(ClientDto client)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateClientAsync(ClientDto client)
    {
        throw new NotImplementedException();
    }

    public Task<int> RemoveClientAsync(ClientDto client)
    {
        throw new NotImplementedException();
    }

    public Task<int> CloneClientAsync(ClientCloneDto client)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanInsertClientAsync(ClientDto client, bool isCloned = false)
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto> GetClientAsync(int clientId)
    {
        throw new NotImplementedException();
    }

    public Task<ClientsDto> GetClientsAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetScopesAsync(string scope, int limit = 0)
    {
        throw new NotImplementedException();
    }

    public List<string> GetGrantTypes(string grant, int limit = 0)
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetAccessTokenTypes()
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetTokenExpirations()
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetTokenUsage()
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetHashTypes()
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetSecretTypes()
    {
        throw new NotImplementedException();
    }

    public List<string> GetStandardClaims(string claim, int limit = 0)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientSecretAsync(ClientSecretsDto clientSecret)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteClientSecretAsync(ClientSecretsDto clientSecret)
    {
        throw new NotImplementedException();
    }

    public Task<ClientSecretsDto> GetClientSecretsAsync(int clientId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ClientSecretsDto> GetClientSecretAsync(int clientSecretId)
    {
        throw new NotImplementedException();
    }

    public Task<ClientClaimsDto> GetClientClaimsAsync(int clientId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ClientPropertiesDto> GetClientPropertiesAsync(int clientId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ClientClaimsDto> GetClientClaimAsync(int clientClaimId)
    {
        throw new NotImplementedException();
    }

    public Task<ClientPropertiesDto> GetClientPropertyAsync(int clientPropertyId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientClaimAsync(ClientClaimsDto clientClaim)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientPropertyAsync(ClientPropertiesDto clientProperties)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteClientClaimAsync(ClientClaimsDto clientClaim)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteClientPropertyAsync(ClientPropertiesDto clientProperty)
    {
        throw new NotImplementedException();
    }

    public List<string> GetSigningAlgorithms(string algorithm, int limit = 0)
    {
        throw new NotImplementedException();
    }

    public List<SelectItemDto> GetProtocolTypes()
    {
        throw new NotImplementedException();
    }
}