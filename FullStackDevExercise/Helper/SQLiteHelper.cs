using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace FullStackDevExercise.Helper
{
  public class SQLiteHelper
  {
    public static readonly SqliteConnectionStringBuilder connectionStringBuilder;

    static SQLiteHelper()
    {
      connectionStringBuilder = new SqliteConnectionStringBuilder();
      connectionStringBuilder.DataSource = "./dolittle.db";
    }
    public SQLiteHelper()
    {
      
    }
    public static void ExecuteNonQuery(string query)
    {
      try
      {
        using (SqliteConnection connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
        {
          connection.Execute(query, commandType: CommandType.Text);
        }
      }
      catch(Exception ex)
      {

      }
    }
    public static object ExecuteScalar(string query)
    {
      object _ = "";
      try
      {
        using (SqliteConnection connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
        {
          _ = connection.ExecuteScalar(query, commandType: CommandType.Text);
        }
      }
      catch (Exception ex)
      {

      }
      return _;
    }
    public static List<T> Query<T>(string query)
    {
      try
      {
        using (SqliteConnection connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
        {
          return connection.Query<T>(query, commandType: CommandType.Text).ToList();
        }
      }
      catch (Exception ex)
      {
        return new List<T>();
      }
    }
  }
}

