using FSDExercise.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.DB
{
  public class FSDExerciseDBContext : DbContext
  {
    private IDbContextTransaction _dbTransaction;
    private readonly IConfiguration _configuration;
    public FSDExerciseDBContext(IConfiguration configuration)
    {
      _configuration = configuration;
      //Database.SetInitializer<FSDExerciseDBContext>(null);
    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    //public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_configuration.GetConnectionString("interviewdb"));
    //=> options.UseSqlite(@"Data Source=./testintv.db");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{

    //  modelBuilder.Entity<Owner>()
    //    .HasKey(o => new { o.Id});
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Owner>();
      modelBuilder.Entity<Pet>();
      modelBuilder.Entity<Appointment>();
    }

    public async Task BeginTransaction()
    {
      if(_dbTransaction is null)
        _dbTransaction = await Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
      try
      {
        await SaveChangesAsync();
        await _dbTransaction.CommitAsync();        
      }
      catch (Exception) {
      }
      finally
      {
        await _dbTransaction.DisposeAsync();
      }
    }

    public async Task Rollback()
    {
      await _dbTransaction.RollbackAsync();
      await _dbTransaction.DisposeAsync();
    }
  }
  
}
