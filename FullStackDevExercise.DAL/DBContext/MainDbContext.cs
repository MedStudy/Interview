using Microsoft.EntityFrameworkCore;
using FullStackDevExercise.DAL.Entity;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace FullStackDevExercise.DAL.DBContext
{
  public class MainDbContext : DbContext
  {
    public DbSet<OwnerEntity> Owners { get; set; }

    public DbSet<PetEntity> Pets { get; set; }

    public DbSet<AppointmentEntity> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=dolittle.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //modelBuilder.Entity<OwnerEntity>(entity =>
      //{
      //  entity.HasKey(e => e.id);
      //  entity.Property(e => e.first_name);
      //  entity.Property(e => e.last_name);
      //});

      //modelBuilder.Entity<PetEntity>(entity =>
      //{
      //  entity.HasKey(e => e.id);
      //  entity.Property(e => e.owner_id).IsRequired();
      //  entity.Property(e => e.type).IsRequired();
      //  entity.Property(e => e.name).IsRequired();
      //  entity.Property(e => e.age).IsRequired();
      //  entity.has(d => d.Owner).WithMany(o => o.);

      //});

      //modelBuilder.Entity<AppointmentEntity>(entity =>
      //{
      //  entity.HasKey(e => e.id);
      //  entity.Property(e => e.pet_id).IsRequired();
      //  entity.Property(e => e.slot_from).IsRequired();
      //  entity.Property(e => e.slot_to).IsRequired(); 
      //  entity.HasOne(d => d.Pet);

      //});
    }
  }
}
