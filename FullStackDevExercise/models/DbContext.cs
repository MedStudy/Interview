using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class MedDbContext : DbContext
  {
    public MedDbContext(DbContextOptions<MedDbContext> options)
                  : base(options)
    {

    }
    public DbSet<owners> Owners { get; set; }
    public DbSet<Pets> Pets { get; set; }
    public DbSet<appointments> Appointments { get; set; }
  }
}
