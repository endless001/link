using Identity.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.DbContexts;

public interface ILogDbContext
{
    DbSet<Log> Logs { get; set; }   
}