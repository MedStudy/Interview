using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Hosting;

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

    private static void SetupDB(SqliteConnection connection) { 
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"  PRAGMA foreign_keys = ON;";
    }

    private static void CreateOwnersTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
drop table owners;
        CREATE TABLE IF NOT EXISTS owners
        (
          id INTEGER PRIMARY KEY
          , FirstName VARCHAR(50) NOT NULL
          , LastName VARCHAR(50) NOT NULL
        )
      ";
      createTable.ExecuteNonQuery();
    }

    private static void CreatePetsTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        Drop table pets;
        CREATE TABLE IF NOT EXISTS pets
        (
          id INTEGER PRIMARY KEY
          , OwnerId INTEGER NOT NULL
          , Type VARCHAR(50) NOT NULL
          , Name VARCHAR(50) NOT NULL
          , Age INTEGER NOT NULL
          , FOREIGN KEY (OwnerId) REFERENCES owners(id) ON DELETE CASCADE ON UPDATE NO ACTION 
        )
      ";
      createTable.ExecuteNonQuery();
    }

    private static void CreateAppointmentsTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        DROP TABLE appointments;
        CREATE TABLE IF NOT EXISTS appointments
        (
          id INTEGER PRIMARY KEY
          , OwnerId INTEGER NOT NULL
          , PetId INTEGER NOT NULL
          , AppointmentDate VARCHAR(50) NOT NULL
          , IsComplete BIT
          , FOREIGN KEY (OwnerId) REFERENCES owners(id) ON DELETE CASCADE ON UPDATE NO ACTION
          , FOREIGN KEY (PetId) REFERENCES pets(id) ON DELETE CASCADE ON UPDATE NO ACTION
        )
      ";
      createTable.ExecuteNonQuery();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
