using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Repositories;

public class ApiScopeRepository<TDbContext> : IApiScopeRepository
    where TDbContext : DbContext, IAdminConfigurationDbContext
{
    
}