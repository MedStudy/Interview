using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FullStackDevExercise.Data.Entities;

namespace FullStackDevExercise.Data
{
  public class DoLittleDbContext : DbContext
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public DoLittleDbContext(
            IHttpContextAccessor httpContextAccessor)
            : base()
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DoLittleDbContext()
        {
        }

        public virtual DbSet<PetEntity> Pets { get; set; }
        public virtual DbSet<OwnerEntity> Owners { get; set; }
        public virtual DbSet<AppointmentEntity> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlite(Config.ConnectionString, null);
        }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entity in this.ChangeTracker.Entries())
            {
                foreach (PropertyEntry property in entity.Properties.ToList().Where(o => !o.Metadata.IsKey()))
                {
                    this.TrimFieldValue(property);
                }
            }
          return base.SaveChanges();
        }

        private void TrimFieldValue(PropertyEntry property)
        {
            var metaData = property.Metadata;
            var currentValue = property.CurrentValue?.ToString();
            var maxLength = metaData.GetMaxLength();

            if (!maxLength.HasValue || currentValue == null)
            {
              return;
            }
            else
            {
              property.CurrentValue = currentValue.Trim();
            }

            if (currentValue.Length > maxLength.Value)
            {
              property.CurrentValue = currentValue.Substring(0, maxLength.Value);
            }
        }
    }
}
