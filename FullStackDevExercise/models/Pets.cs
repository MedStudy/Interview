using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class PetsList : Pets
  {
    public string owner_name { get; set; }
  }
  public class Pets : Ipets
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    Ipets Ipets.createpet(Ipets data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "insert into pets(owner_id,type,name,age) values ('" + data.owner_id + "','" + data.type + "','" + data.name + "','" + data.age + "'); select last_insert_rowid() as id";
      selectCmd.CommandType = System.Data.CommandType.Text;
      string id = selectCmd.ExecuteScalar().ToString();
      data.id = Convert.ToInt32(id);
      return data;
    }

    string Ipets.deletepet(string id)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "PRAGMA foreign_keys=ON; delete from pets where id=" + Convert.ToInt32(id);
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return id;
    }

    IEnumerable<Ipets> Ipets.getAllpets()
    {
      List<PetsList> result = new List<PetsList>();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "SELECT id,owner_id,(select o.first_name || ' ' || o.last_name from owners o where o.id=p.owner_id) as owner_name,name,type,age FROM pets p";

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
          PetsList a = new PetsList();
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.owner_id = Convert.ToInt32(reader["owner_id"].ToString());
          a.owner_name = reader["owner_name"].ToString();
          a.name = reader["name"].ToString();
          a.type = reader["type"].ToString();
          a.age = Convert.ToInt32(reader["age"].ToString());
          result.Add(a);
        }
      }

      return result;
    }

    Ipets Ipets.getpets(string id)
    {
      Pets a = new Pets();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "SELECT id,owner_id,type,name,age FROM pets where id=" + Convert.ToInt32(id);

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.owner_id = Convert.ToInt32(reader["owner_id"].ToString());
          a.name = reader["name"].ToString();
          a.type = reader["type"].ToString();
          a.age = Convert.ToInt32(reader["age"].ToString());
        }
      }

      return a;
    }

    Ipets Ipets.updatepet(Ipets data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "update pets set owner_id='" + data.owner_id + "',type='" + data.type + "',name='" + data.name + "',age='" + data.age + "' where id=" + data.id;
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return data;
    }
  }
}
