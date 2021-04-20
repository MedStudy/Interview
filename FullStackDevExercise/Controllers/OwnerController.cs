using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using FullStackDevExercise.Model;

namespace WebAPI.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class OwnerController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public OwnerController(IConfiguration configuration, IWebHostEnvironment env)
    {
      _configuration = configuration;
      _env = env;
    }

    [HttpGet]
    public JsonResult Get()
    {
      string query = @"
                    select id, first_name, last_name
                    from owners
                    ";
      DataTable table = new DataTable();

      string sqlDataSource = _configuration.GetConnectionString("PetAppConnect");
      SqliteDataReader myReader;
      using (SqliteConnection myCon = new SqliteConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqliteCommand myCommand = new SqliteCommand(query, myCon))
        {
          myReader = myCommand.ExecuteReader();
          table.Load(myReader); ;

          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult(table);
    }


    [HttpPost]
    public JsonResult Post(OwnerModel owner)
    {
      string query = @"
                    insert into owners 
                    (first_name,last_name)
                    values 
                    (
                    '" + owner.first_name + @"'
                    ,'" + owner.last_name + @"'
                    )
                    ";
      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("PetAppConnect");
      SqliteDataReader myReader;
      using (SqliteConnection myCon = new SqliteConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqliteCommand myCommand = new SqliteCommand(query, myCon))
        {
          myReader = myCommand.ExecuteReader();
          table.Load(myReader); ;

          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult("Added Successfully");
    }


    [HttpPut]
    public JsonResult Put(OwnerModel owner)
    {
      string query = @"
                    update owners set 
                    first_name = '" + owner.first_name + @"'
                    ,Last Name = '" + owner.last_name + @"'
                    where id = " + owner.id + @" 
                    ";
      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("PetAppConnect");
      SqliteDataReader myReader;
      using (SqliteConnection myCon = new SqliteConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqliteCommand myCommand = new SqliteCommand(query, myCon))
        {
          myReader = myCommand.ExecuteReader();
          table.Load(myReader); ;

          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult("Updated Successfully");
    }


    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      string query = @"
                    delete from owners
                    where id = " + id + @" 
                    ";
      DataTable table = new DataTable();
      string sqlDataSource = _configuration.GetConnectionString("PetAppConnect");
      SqliteDataReader myReader;
      using (SqliteConnection myCon = new SqliteConnection(sqlDataSource))
      {
        myCon.Open();
        using (SqliteCommand myCommand = new SqliteCommand(query, myCon))
        {
          myReader = myCommand.ExecuteReader();
          table.Load(myReader); ;

          myReader.Close();
          myCon.Close();
        }
      }

      return new JsonResult("Deleted Successfully");
    }



  }
}
