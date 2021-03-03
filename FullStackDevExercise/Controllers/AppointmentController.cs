using FullStackDevExercise.Models;
using FullStackDevExercise.Services.Contracts;
using FullStackDevExercise.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FullStackDevExercise.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentController : ControllerBase
  {
    private readonly IAppointmentService service;
    public AppointmentController(IAppointmentService ApppointmentService)
    {
      service = ApppointmentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var data = service.GetAll();
      return Ok(data);
    }

    [Route("by-date/{bookDate}")]
    public IActionResult GetByDate(string bookDate)
    {
      var result = service.GetByDate(DateTime.Parse(bookDate));
      return Ok(result);
    }

    //TODO Later
    //[Route("by-month/{month}")]
    //public IActionResult GetByMonth(int month)
    //{
    //  var result = service.GetByDate(date);
    //  return Ok(result);
    //}

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var data = service.GetById(id);
      return Ok(data);
    }

    // POST api/<OwnerController>
    //Not following a 3 layered architecture here.
    //using DTO itself as there is no change in properties else a different view modal class is preferred.
    [HttpPost]
    public int Post(AppointmentDTO dto)
    {
      return service.Save(dto);
    }

    //// PUT api/<OwnerController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<OwnerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      service.Delete(id);
    }
  }
}
