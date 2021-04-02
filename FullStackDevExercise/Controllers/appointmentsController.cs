using FullStackDevExercise.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class appointmentsController : ControllerBase
  {
    Iappointment _appointment;
    public appointmentsController(Iappointment appointment)
    {
      _appointment = appointment;
    }

    [HttpGet]
    public IActionResult getAll()
    {
      var result = _appointment.getAllappointments();
      return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult get(string id)
    {
      var result = _appointment.getappointment(id);
      return Ok(result);
    }

    [HttpPost]
    public IActionResult create(appointments data)
    {
      var result = _appointment.createappointment(data);
      return Ok(result);
    }
    [HttpPut]
    public IActionResult update(appointments data)
    {
      var result = _appointment.updateappointment(data);
      return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult delete(string id)
    {
      var result = _appointment.deleteappointment(id);
      return Ok(result);
    }
  }
}
