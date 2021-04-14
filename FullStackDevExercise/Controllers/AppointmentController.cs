using FSDExercise.Common.Models;
using FSDExercise.DB;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]")]
  public class AppointmentController : ControllerBase
  {
      private readonly FSDExerciseDBContext _dbContext;
      private readonly IConfiguration _configuration;
      private readonly ILogger<AppointmentController> _logger;
      private readonly IAppointmentService _appointmentService;
      public AppointmentController(FSDExerciseDBContext dbContext,
        IConfiguration configuration,
        ILogger<AppointmentController> logger,
        IAppointmentService appointmentService)
      {
        _dbContext = dbContext;
        _configuration = configuration;
        _logger = logger;
        _appointmentService = appointmentService;
      }

      [HttpGet]
      [Route("All")]
      public async Task<IActionResult> GetAll()
      {
        var result = await _appointmentService.GetAllAppointments();
        if (result != null)
          return Ok(result);

        return NoContent();
      }

      [HttpGet]
      [Route("{id}")]
      public async Task<IActionResult> Get(int id)
      {
        var result = await _appointmentService.GetAppointmentDetails(id);
        if (result != null)
          return Ok(result);

        return NotFound("Appointment Details not found");
      }

      //[HttpPost]
      //public async Task<IActionResult> Post([FromBody] AppointmentRequest appointmentRequest)
      //{
      //  if (!ModelState.IsValid)
      //    return BadRequest("Please verify the input provided");

      //  var result = await _appointmentService.RequestAppointment(appointmentRequest);
      //  if (result.isSuccess)
      //    return Ok("Appointment Confirmed.");

      //  return UnprocessableEntity(result.ErrorMessage);
      //}

      [HttpPut]
      [Route("{id}/cancel")]
      public async Task<IActionResult> Put(int id)
      {
        if (id == 0)
          return BadRequest("Please verify the input provided");

        var result = await _appointmentService.CancelAppointment(id);
        if (result.isSuccess)
          return Ok("Appointment Cancelled.");

        return UnprocessableEntity(result.ErrorMessage);
      }

    //[HttpPut]    
    //public async Task<IActionResult> Put(OwnerRequest ownerRequest)
    //{
    //  var result = await _ownerService.AddOwner(ownerRequest);
    //  if (result.isSuccess)
    //    return Ok("Ownser added successfully.");

    //  return UnprocessableEntity(result.ErrorMessage);
    //}

      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
        var result = await _appointmentService.DeleteAppointment(id);
        if (result.isSuccess)
          return Ok("Appointment deleted successfully.");

        return UnprocessableEntity(result.ErrorMessage);
      }

  }
}
