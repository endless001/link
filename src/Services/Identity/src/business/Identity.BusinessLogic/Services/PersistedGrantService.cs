using Identity.BusinessLogic.Dtos.Grant;

namespace Identity.BusinessLogic.Services;

public class PersistedGrantService:IPersistedGrantService
{
    public Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<PersistedGrantDto> GetPersistedGrantAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeletePersistedGrantAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeletePersistedGrantsAsync(string userId)
    {
        throw new NotImplementedException();
    }
}