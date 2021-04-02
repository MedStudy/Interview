using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class owners : Iowner
  {
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }

    Iowner Iowner.createowner(Iowner data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "insert into owners(first_name,last_name) values ('" + data.first_name + "','" + data.last_name + "'); select last_insert_rowid() as id";
      selectCmd.CommandType = System.Data.CommandType.Text;
      string id = selectCmd.ExecuteScalar().ToString();
      data.id = Convert.ToInt32(id);
      return data;
    }
    Iowner Iowner.getowners(string id)
    {
      owners a = new owners();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "SELECT id,first_name,last_name FROM owners where id="+Convert.ToInt32(id);

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
         
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.first_name = reader["first_name"].ToString();
          a.last_name = reader["last_name"].ToString();
        }
      }

      return a;
    }
    string Iowner.deleteowner(string id)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "PRAGMA foreign_keys=ON; delete from owners where id=" + Convert.ToInt32(id);
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return id;
    }

    IEnumerable<Iowner> Iowner.getAllowners()
    {
      List<owners> result = new List<owners>();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "SELECT id,first_name,last_name FROM owners";

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
          owners a = new owners();
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.first_name = reader["first_name"].ToString();
          a.last_name = reader["last_name"].ToString();
          result.Add(a);
        }
      }

      return result;
    }

    Iowner Iowner.updateowner(Iowner data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "update owners set first_name='" + data.first_name + "',last_name='" + data.last_name + "' where id=" + data.id;
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return data;
    }
  }
}
