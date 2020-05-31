using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Entities;
using FullStackDevExercise.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]/[action]")]
  public class AppointmentController : BaseController
  {
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult GetAppointments(int id)
    {
      List<Appointment> appointments = businessLayer.GetAppointments(id);
      return Json(appointments);
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult DeleteAppointment(int id)
    {
      return Json(businessLayer.DeleteAppointment(id));
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult MarkCompleteAppointment(int id)
    {
      return Json(businessLayer.MarkCompleteAppointment(id));
    }
    [HttpPost]
    public ActionResult AddAppointment([FromBody] Appointment appointment)
    {
      int id = businessLayer.AddAppointment(appointment);
      return Json(id);
    }
  }
}
