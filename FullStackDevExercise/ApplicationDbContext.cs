using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FullStackDevExercise.Model;
using Microsoft.EntityFrameworkCore;


namespace FullStackDevExercise
{
  public class ApplicationDbContext : DbContext
  {
    
         public DbSet<PetModel> Pets { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
  }
}

