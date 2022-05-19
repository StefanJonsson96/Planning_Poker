﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PlanningPoker.Domain;

namespace PlanningPoker.Persistence;

public class IdentityContext : IdentityDbContext<PlanningPokerUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
        //RelationalDatabaseCreator databaseCreator =
        //    (RelationalDatabaseCreator)Database.GetService<IDatabaseCreator>();
        //databaseCreator.CreateTables();


        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.SeedUser();
        builder.SeedRole();
        builder.SeedUserRole();
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
