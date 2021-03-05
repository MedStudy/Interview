using System;
using System.Linq;
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
      //var createTable = connection.CreateCommand();
      //createTable.CommandText = @"
      //  insert into vets select 1, 'Dr Doberman';
      //  insert into vets select 2, 'Dr Poodle';
      //";
      //createTable.ExecuteNonQuery();


//      var command = @"
//insert into owners select 20, 'Noella', 'Sacks';
//insert into owners select 3, 'Alfreda', 'Kegler';
//insert into owners select 4, 'Freda', 'Napoleon';
//insert into owners select 5, 'Cleo', 'Ratledge';
//insert into owners select 6, 'Deloris', 'Kephart';
//insert into owners select 7, 'Harrison', 'Holman';
//insert into owners select 8, 'Gregg', 'Trusty';
//insert into owners select 9, 'Shavonda', 'Leftwich';
//insert into owners select 10, 'Shonda', 'Litton';
//insert into owners select 11, 'Stephane', 'Triana';
//insert into owners select 12, 'Ying', 'Halstead';
//insert into owners select 13, 'Kaylee', 'Killingsworth';
//insert into owners select 14, 'Lisette', 'Nakagawa';
//insert into owners select 15, 'Marlene', 'Nettles';
//insert into owners select 16, 'Emerson', 'Petrella';
//insert into owners select 17, 'Ermelinda', 'Anders';
//insert into owners select 18, 'Rina', 'Carreira';
//insert into owners select 19, 'Sari', 'Padua';


//";
//      var createTable =  connection.CreateCommand();
//      createTable.CommandText = command;
//      createTable.ExecuteNonQuery();

      var types = new string[] { "cat", "dog" };
      var names = new string[]
      {
        "Sophia",
"Jimmuy",
"Nibbles",
"Domino",
"Hugo",
"Mason",
"Miko",
"Polly",
"Harpo",
"Titus",
"Giant",
"Thumper",
"Tommy",
"Kerry",
"Miles",
"Lou",
"Smoke",
"Puddles",
"Tito",
"Brandi",
"Axle",
"Kallie",
"Ming",
"Skinny",
"Cooper",
"Franky",
"Gilda",
"Niki"
      };

      var rand = new Random();

     foreach( var item in Enumerable.Range(2, 18))
      {
        var name = names[rand.Next(0, names.Length - 1)];
        var type = types[rand.Next(0, types.Length - 1)];

        var createTable = connection.CreateCommand();
        createTable.CommandText = $"insert into pets select {item}, {item}, '{type}', '{name}', {rand.Next(1,20)};";
        createTable.ExecuteNonQuery();
      }

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
