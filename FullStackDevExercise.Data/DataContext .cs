using FullStackDevExercise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FullStackDevExercise.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=PetsDB.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Owner>().ToTable("owners")
        .HasData(new Owner { id = 1, firstName="Rony", lastName="Jose" }, new Owner { id = 2, firstName = "Ann", lastName = "Jose" });
      modelBuilder.Entity<Pet>().ToTable("pets")
        .HasData(new Pet { id = 1, name="Dude", type="Huskey Dog", age=1 });
        
    }
  }
}
