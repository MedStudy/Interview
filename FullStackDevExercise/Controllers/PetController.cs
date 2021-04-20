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
  public class PetController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public PetController(IConfiguration configuration, IWebHostEnvironment env)
    {
      _configuration = configuration;
      _env = env;
    }

    [HttpGet]
    public JsonResult Get()
    {
      string query = @"
                    select id, name, age , type ,owner_id
                    from pets
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
    public JsonResult Post(PetModel pet)
    {
      string query = @"
                    insert into pets 
                    (name,owner_id,type,age)
                    values 
                    (
                    '" + pet.name + @"'
                    ,'" + pet.owner_id + @"'
                    ,'" + pet.type + @"'
                    ,'" + pet.age + @"'
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

    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      string query = @"
                    delete from pets
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
