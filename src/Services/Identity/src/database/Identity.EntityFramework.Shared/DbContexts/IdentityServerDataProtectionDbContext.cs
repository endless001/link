﻿using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Shared.DbContexts;
public class IdentityServerDataProtectionDbContext : DbContext, IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    public IdentityServerDataProtectionDbContext(DbContextOptions<IdentityServerDataProtectionDbContext> options)
        : base(options) { }
}