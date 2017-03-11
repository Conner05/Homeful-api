using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() {

        }

        /*public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer("Server=tcp:homeful.database.windows.net,1433;Initial Catalog=Homeful;Persist Security Info=False;User ID=c4tk@homeful;Password=N@$hv1ll3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Occupant> Occupants { get; set; }
    }
}
