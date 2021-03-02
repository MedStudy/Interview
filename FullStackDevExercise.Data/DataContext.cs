using FullStackDevExercise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FullStackDevExercise.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlite("Data Source=PetsDB.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Owner>().ToTable("owners")
        .HasData(new Owner { id = 1, first_name = "Peter", last_name = "Pan" });
      modelBuilder.Entity<Pet>().ToTable("pets")
        .HasData(new Pet { id = 1, name = "Duke", type = "dog", age = 1, owner_id = 1 });
      modelBuilder.Entity<Appointment>().ToTable("appointments");
    }
  }
}
