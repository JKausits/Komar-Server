using Komar.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Komar.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Db Sets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Trackable);
            foreach (var entry in entries)
            {
                var entity = entry.Entity as Trackable;
                entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
