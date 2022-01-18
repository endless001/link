﻿using Identity.BusinessLogic.Dtos.Grant;
using Identity.BusinessLogic.Mappers;
using Identity.BusinessLogic.Resources;
using Identity.BusinessLogic.Shared.ExceptionHandling;
using Identity.EntityFramework.Repositories;

namespace Identity.BusinessLogic.Services;

public class PersistedGrantService : IPersistedGrantService
{
    protected readonly IPersistedGrantRepository PersistedGrantRepository;
    protected readonly IPersistedGrantServiceResources PersistedGrantServiceResources;
    public PersistedGrantService(IPersistedGrantRepository persistedGrantRepository, IPersistedGrantServiceResources persistedGrantServiceResources)
    {
        PersistedGrantRepository = persistedGrantRepository;
        PersistedGrantServiceResources = persistedGrantServiceResources;
    }

    public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = await PersistedGrantRepository.GetPersistedGrantsByUsersAsync(search, page, pageSize);
        var persistedGrantsDto = pagedList.ToModel();


        return persistedGrantsDto;
    }

    public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10)
    {
        var exists = await PersistedGrantRepository.ExistsPersistedGrantsAsync(subjectId);
        if (!exists) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description, subjectId), PersistedGrantServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description);

        var pagedList = await PersistedGrantRepository.GetPersistedGrantsByUserAsync(subjectId, page, pageSize);
        var persistedGrantsDto = pagedList.ToModel();

        return persistedGrantsDto;
    }

    public virtual async Task<PersistedGrantDto> GetPersistedGrantAsync(string key)
    {
        var persistedGrant = await PersistedGrantRepository.GetPersistedGrantAsync(key);
        if (persistedGrant == null) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantServiceResources.PersistedGrantDoesNotExist().Description, key), PersistedGrantServiceResources.PersistedGrantDoesNotExist().Description);
        var persistedGrantDto = persistedGrant.ToModel();

        return persistedGrantDto;
    }

    public virtual async Task<int> DeletePersistedGrantAsync(string key)
    {
        var deleted = await PersistedGrantRepository.DeletePersistedGrantAsync(key);

        return deleted;
    }

    public virtual async Task<int> DeletePersistedGrantsAsync(string userId)
    {
        var deleted = await PersistedGrantRepository.DeletePersistedGrantsAsync(userId);

        return deleted;
    }
}