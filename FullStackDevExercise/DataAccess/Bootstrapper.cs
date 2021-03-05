using Microsoft.Data.Sqlite;

namespace FullStackDevExercise.DataAccess
{
  public class Bootstrapper
  {
    public static void BootstrapSchema()
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";

      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      SetupDB(connection);
      CreateOwnersTable(connection);
      CreatePetsTable(connection);
      CreateVetTable(connection);
      CreateAvailabilityTable(connection);
      CreateAppointmentsTable(connection);
    }

    public static void SeedData(SqliteConnection connection)
    {
      //insert times.
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        insert into availability select 1, '9am'
      ";
      createTable.ExecuteNonQuery();
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
    }
    private static void CreateAppointmentsTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS appointments
        (
          id INTEGER PRIMARY KEY
          , owner_id INT NOT NULL
          , pet_id INT NOT NULL
          , vet_id INT NOT NULL
          , scheduled_date text 
          , FOREIGN KEY (owner_id) REFERENCES owners(id) ON DELETE CASCADE ON UPDATE NO ACTION
          ,FOREIGN KEY (pet_id) REFERENCES pets(id) ON DELETE CASCADE ON UPDATE NO ACTION
          ,FOREIGN KEY (vet_id) REFERENCES vets(id) ON DELETE CASCADE ON UPDATE NO ACTION
        )
      ";
      createTable.ExecuteNonQuery();
    }
    private static void CreateVetTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS vets
        (
          id INTEGER PRIMARY KEY
          , name  varchar(250) NOT NULL
          
        )
      ";
      createTable.ExecuteNonQuery();
    }
    private static void CreateAvailabilityTable(SqliteConnection connection)
    {
      var createTable = connection.CreateCommand();
      createTable.CommandText = @"
        CREATE TABLE IF NOT EXISTS availability
        (
          id INTEGER PRIMARY KEY
          , name  varchar(250) NOT NULL
          
        )
      ";
      createTable.ExecuteNonQuery();
    }
  }
}
