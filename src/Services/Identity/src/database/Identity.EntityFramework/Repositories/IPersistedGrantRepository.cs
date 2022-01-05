﻿using Identity.EntityFramework.Entities;
using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;

namespace Identity.EntityFramework.Repositories;

public interface IPersistedGrantRepository
{
    Task<PagedList<PersistedGrantDataView>> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10);
    Task<PagedList<PersistedGrant>> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10);
    Task<PersistedGrant> GetPersistedGrantAsync(string key);
    Task<int> DeletePersistedGrantAsync(string key);
    Task<int> DeletePersistedGrantsAsync(string userId);
    Task<bool> ExistsPersistedGrantsAsync(string subjectId);
    Task<int> SaveAllChangesAsync();
    bool AutoSaveChanges { get; set; }
}