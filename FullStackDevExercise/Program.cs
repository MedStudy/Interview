using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Hosting;
using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using FullStackDevExercise.DAL.DBContext;

namespace FullStackDevExercise
{
  public class Program
  {    
    public static void Main(string[] args)
    {
      BootstrapData();
      CreateHostBuilder(args).Build().Run();
    }

    private static void BootstrapData()
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";

      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      SetupDB(connection);
      CreateOwnersTable(connection);
      CreatePetsTable(connection);
      CreateAppointmentsTable(connection);
    }    
    private static void SetupDB(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"  PRAGMA foreign_keys = ON;";
    }

    private static void CreateOwnersTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS owners
        (
          id INTEGER PRIMARY KEY
          , first_name VARCHAR(50) NOT NULL
          , last_name VARCHAR(50) NOT NULL
        )
      ";
      createTable.ExecuteNonQuery();
      createTable.Dispose();

      // Seeding data
      var owners = new List<OwnerEntity>(new[] {
        new OwnerEntity{id =1, first_name = "Pet", last_name = "Owner1"},
        new OwnerEntity{id =2, first_name = "Pet", last_name = "Owner2"}
      });
      using(var dbcontext = new MainDbContext())
      {
        var dbValues = dbcontext.Owners.ToList();
        var ownersToInsert = owners.Where(p => !dbValues.Any(p2 => p2.id == p.id));
        dbcontext.Owners.AddRange(ownersToInsert);
        dbcontext.SaveChanges();
      }      
    }

    private static void CreateAppointmentsTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS appointments
        (
          id INTEGER PRIMARY KEY AUTOINCREMENT          
          , pet_id INT NOT NULL
          , slot_from	VARCHAR(36)
          , slot_to	VARCHAR(36)
          , FOREIGN KEY (pet_id) REFERENCES pets(id) ON DELETE CASCADE ON UPDATE NO ACTION
        )
      ";
      createTable.ExecuteNonQuery();
    }
    private static void CreatePetsTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS pets
        (
          id INTEGER PRIMARY KEY
          , owner_id INT NOT NULL
          , type VARCHAR(50) NOT NULL
          , name VARCHAR(50) NOT NULL
          , age INT NOT NULL
          , FOREIGN KEY (owner_id) REFERENCES owners(id) ON DELETE CASCADE ON UPDATE NO ACTION 
        )
      ";
      createTable.ExecuteNonQuery();

      // Seeding data..
      var pets = new List<PetEntity>(new[]{
        new PetEntity{id=1, type ="dog", owner_id = 1, name = "Pug pup", age=3},
        new PetEntity{id=2, type ="cat", owner_id = 1, name = "Meow", age=3},
        new PetEntity{id=3, type ="dog", owner_id = 1, name = "Lab", age=6},
        new PetEntity{id=4, type ="dog", owner_id = 2, name = "New Pup", age=3},
        new PetEntity{id=5, type ="cat", owner_id = 2, name = "Meow 2", age=5}        
      });
      using (var dbcontext = new MainDbContext())
      {
        var dbValues = dbcontext.Pets.ToList();
        var petsToInsert = pets.Where(p => !dbValues.Any(p2 => p2.id == p.id));
        dbcontext.Pets.AddRange(petsToInsert);
        dbcontext.SaveChanges();
      }      
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
