using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class appointments : Iappointment
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    public int pet_id { get; set; }
    public string date { get; set; }
    public int fromtime { get; set; }
    public int totime { get; set; }
    public string owner_name { get; set; }

    public string pet_name { get; set; }

    public Iappointment createappointment(Iappointment data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "insert into appointments(owner_id,pet_id,date,fromtime,totime) values ('" + data.owner_id + "','" + data.pet_id + "','" + data.date + "','" + data.fromtime + "','" + data.totime + "'); select last_insert_rowid() as id";
      selectCmd.CommandType = System.Data.CommandType.Text;
      string id = selectCmd.ExecuteScalar().ToString();
      data.id = Convert.ToInt32(id);
      return data;
    }

    public string deleteappointment(string id)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "PRAGMA foreign_keys=ON; delete from appointments where id=" + Convert.ToInt32(id);
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return id;
    }

    public IEnumerable<Iappointment> getAllappointments()
    {
      List<appointments> result = new List<appointments>();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = @"SELECT id,
((select o.first_name || ' ' || o.last_name from owners o where o.id=p.owner_id)) as owner_name,
((select o.name from pets o where o.id=p.pet_id)) as pet_name,
owner_id,pet_id,date,fromtime,totime FROM appointments p";

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
          appointments a = new appointments();
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.owner_id = Convert.ToInt32(reader["owner_id"].ToString());
          a.pet_id = Convert.ToInt32(reader["pet_id"].ToString());
          a.fromtime = Convert.ToInt32(reader["fromtime"].ToString());
          a.totime = Convert.ToInt32(reader["totime"].ToString());
          a.date = reader["date"].ToString();
          a.owner_name = reader["owner_name"].ToString();
          a.pet_name = reader["pet_name"].ToString();
          result.Add(a);
        }
      }

      return result;
    }

    public Iappointment getappointment(string id)
    {
      appointments a = new appointments();
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = @"SELECT id,
((select o.first_name || ' ' || o.last_name from owners o where o.id=p.owner_id)) as owner_name,
((select o.name from pets o where o.id=p.pet_id)) as pet_name,
owner_id,pet_id,date,fromtime,totime FROM appointments p where id=" + Convert.ToInt32(id);

      using (var reader = selectCmd.ExecuteReader())
      {
        while (reader.Read())
        {
          a.id = Convert.ToInt32(reader["id"].ToString());
          a.owner_id = Convert.ToInt32(reader["owner_id"].ToString());
          a.pet_id = Convert.ToInt32(reader["pet_id"].ToString());
          a.fromtime = Convert.ToInt32(reader["fromtime"].ToString());
          a.date = reader["date"].ToString();
          a.totime = Convert.ToInt32(reader["totime"].ToString());
          a.owner_name = reader["owner_name"].ToString();
          a.pet_name = reader["pet_name"].ToString();
        }
      }

      return a;
    }

    public Iappointment updateappointment(Iappointment data)
    {
      var connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
      using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
      connection.Open();
      var selectCmd = connection.CreateCommand();
      selectCmd.CommandText = "update appointments set owner_id='" + data.owner_id + "',pet_id='" + data.pet_id + "',date='" + data.date + "',fromtime='" + data.fromtime + "',totime='" + data.totime + "' where id=" + data.id;
      selectCmd.CommandType = System.Data.CommandType.Text;
      selectCmd.ExecuteNonQuery();
      return data;
    }
  }
}
