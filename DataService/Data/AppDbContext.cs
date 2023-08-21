using Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Data
{
    public class AppDbContext : DbContext
    {
        // Define db entities
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // define relations between entities

            modelBuilder.Entity<Achievement>(entity =>
                entity.HasOne(d => d.Driver)
                .WithMany(a => a.Achievements)
                .HasForeignKey(di => di.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Driver"));
        }

    }
}
