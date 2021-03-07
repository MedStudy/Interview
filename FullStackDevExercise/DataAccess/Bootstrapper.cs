using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackDevExercise.Contracts;
using Microsoft.Data.Sqlite;

namespace FullStackDevExercise.DataAccess
{
  public class Bootstrapper : IBootstrapper
  {
    public async Task SeedOwnersAsync(SqliteConnection connection)
    {
      var command = connection.CreateCommand();
      var commandBuilder = new StringBuilder();
      long index = 1;
      commandBuilder.AppendLine("delete from owners;");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Karlene', 'Keim';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Palmira', 'Putnam';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Hallie', 'Halpin';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Latricia', 'Leduc';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Clemente', 'Chittum';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Kenisha', 'Kimmer';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Paulina', 'Purdue';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Kiesha', 'Kenyon';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Zonia', 'Zimmerer';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Tabetha', 'Tabor';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Andre', 'Addario';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Akiko', 'Abdulla';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Margherita', 'Miramontes';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Kylee', 'Kasprzak';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Demarcus', 'Dungan';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Brandon', 'Bigelow';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Leeanne', 'Leadbetter';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Elisha', 'Eisenberg';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Libby', 'Leininger';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Marcellus', 'Montalbo';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Mitch', 'Mcleroy';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Marceline', 'Mogensen';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Cassandra', 'Chalmers';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Chas', 'Critelli';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Theodore', 'Taillon';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Sharri', 'Segrest';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Otha', 'Orme';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Aileen', 'Antrim';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Jeannie', 'Jaramillo';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Maragret', 'Meszaros';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Babara', 'Belfiore';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Shirlene', 'Sidener';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Trudi', 'Tuller';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Juliet', 'Juckett';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Echo', 'Estrella';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Jamison', 'Julius';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Arletta', 'Ahlers';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Anglea', 'Alter';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Charleen', 'Cabana';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Raelene', 'Riggle';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Dollie', 'David';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Lynnette', 'Loux';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Chaya', 'Columbus';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Liz', 'Ledbetter';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Mila', 'Meraz';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Sherika', 'Swofford';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Gladys', 'Gimbel';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Milo', 'Mccuiston';");
      commandBuilder.AppendLine($"insert into owners select {index++}, 'Ray', 'Roig';");
      commandBuilder.AppendLine($"insert into owners select {index}, 'Felicidad', 'Faw';");
      command.CommandText = commandBuilder.ToString();
      await command.ExecuteNonQueryAsync();
    }

    public async Task SeedPetsAsync(SqliteConnection connection)
    {
      var command = connection.CreateCommand();
      var commandBuilder = new StringBuilder();
      commandBuilder.AppendLine("delete from pets;");
      var types = new string[] { "cat", "dog" };
      var names = new string[]
      {
   "Rosa",
"Doc",
"Winter",
"Madison",
"Mason",
"Bosco",
"Misha",
"Deacon",
"Duffy",
"Friday",
"Crackers",
"Smokey",
"Stuart",
"Schultz",
"Scooter",
"Harry",
"Gabby",
"Moonshine",
"Birdy",
"Tango",
"Luci",
"Dave",
"Mittens",
"Grover",
"Nickers",
"Bear",
"Sable",
"Ivory",
"Pumpkin",
"Georgie",
"Mister",
"Pongo",
"Freddy",
"Gunner",
"Snowy",
"Wallace",
"Brittany",
"Winston",
"Slick",
"Jellybean",
"Blast",
"Sawyer",
"JJ",
"Linus",
"Brooke",
"Skyler",
"Thunder",
"Jazmie",
"Coco",
"Bruno"
      };

      var rand = new Random();

      foreach (var ownerId in Enumerable.Range(1, names.Length))
      {
        var name = names[rand.Next(0, names.Length - 1)];
        var type = types[rand.Next(0, types.Length - 1)];

        commandBuilder.AppendLine($"insert into pets select {ownerId}, {ownerId}, '{type}', '{name}', {rand.Next(1, 20)};");
      }
      command.CommandText = commandBuilder.ToString();
      await command.ExecuteNonQueryAsync();
    }

    public async Task SeedVetsAsync(SqliteConnection connection)
    {
      var command = connection.CreateCommand();
      var commandBuilder = new StringBuilder();
      commandBuilder.AppendLine(@"delete from  vets;");
      commandBuilder.AppendLine(@"insert into vets select 1, 'Dr Doberman';");
      commandBuilder.AppendLine(@"insert into vets select 2, 'Dr Dolittle';");
      commandBuilder.AppendLine(@"insert into vets select 3, 'Dr Poodle';");
      command.CommandText = commandBuilder.ToString();
      await command.ExecuteNonQueryAsync();
    }

    public async Task SeedAppointmentsAsync(SqliteConnection connection)
    {
      var command = connection.CreateCommand();
      var commandBuilder = new StringBuilder();
      commandBuilder.AppendLine(@"delete from  appointments;");

      command.CommandText = commandBuilder.ToString();
      await command.ExecuteNonQueryAsync();
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

    public async Task BootstrapWithOptions(string[] args)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";

      using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
      {
        await connection.OpenAsync();

        if (args[0] == "bootstrap")
        {
          SetupDB(connection);
          CreateOwnersTable(connection);
          CreatePetsTable(connection);
          CreateVetTable(connection);
          CreateAvailabilityTable(connection);
          CreateAppointmentsTable(connection);
        }
        if (args.Length >= 2 && args[1] == "seed")
        {
          var tablesToSeed = args.Skip(2);
          if (tablesToSeed.Any())
          {
            await SeedAppointmentsAsync(connection);
            foreach (var table in tablesToSeed)
            {
              switch (table)
              {
                case "owners": await SeedOwnersAsync(connection); break;
                case "pets": await SeedPetsAsync(connection); break;
                case "vets": await SeedVetsAsync(connection); break;
              }
            }
          }
        }
      }
    }
  }
}
