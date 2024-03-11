using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Achievement>(entity =>
            entity.HasOne(a => a.Driver)
            .WithMany(d => d.Achievements)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(a => a.DriverId)
            .HasConstraintName("FK_Achievements_Driver"));
        }
    }
}
