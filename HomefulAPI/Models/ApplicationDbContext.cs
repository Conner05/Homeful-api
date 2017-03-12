using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HomefulAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(
#if DEBUG
            System.Configuration.ConfigurationManager.ConnectionStrings["Development"].ConnectionString
#else
            "Production"
#endif
            )
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, MigrateDBConfiguration>());
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Occupant> Occupants { get; set; }
    }






    public class MigrateDBConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public MigrateDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}