
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication.Data
{
    public class DbContextFactory : IDbContextFactory<ApplicationDbContext>
    {

        ApplicationDbContext IDbContextFactory<ApplicationDbContext>.Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("local.db");
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}