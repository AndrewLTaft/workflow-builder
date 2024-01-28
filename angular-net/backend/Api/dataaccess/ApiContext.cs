using Api.DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api.DataAcess;

public class ApiContext : DbContext
{
    public DbSet<Api.DataAcess.Models.Workflow> Workflows { get; set; }

    public DbSet<Api.DataAcess.Models.Part> Parts { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) { }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
    }
    #endregion
}