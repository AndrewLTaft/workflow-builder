using Api.DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api.DataAcess;

public class ApiContext : DbContext
{
    //public DbSet<Workflow> Workflows { get; set; }

    
    public ApiContext (DbContextOptions<ApiContext> options)
            : base(options) {}
}