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
  public class AppointmentController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    public AppointmentController(IConfiguration configuration, IWebHostEnvironment env)
    {
      _configuration = configuration;
      _env = env;
    }

    [HttpGet]
    public JsonResult Get()
    {
      string query = @"
                    select appointment_id,date,time,owner_name,pet_name
                    from appointments
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
    public JsonResult Post(AppointmentsModel appointment)
    {
      string query = @"
                    insert into appointments 
                    (date,time,owner_name,pet_name)
                    values 
                    (
                    '" + appointment.date + @"'
                    ,'" + appointment.time + @"'
                    ,'" + appointment.owner_name + @"'
                    ,'" + appointment.pet_name + @"'
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
                    delete from appointments
                    where appointment_id = " + id + @" 
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
