using System.Collections.Generic;
using System.Threading.Tasks;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class ScheduleController : BaseController
  {
    public ScheduleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IEnumerable<AppointmentModel>> GetSchedules()
    {
      var schedules = await Mediator.Send(new SearchScheduleRequest());
      return schedules.Models;
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<ObjectResult> DeleteSchedule([FromRoute] int id)
    {
      var Schedule = await Mediator.Send(new DeleteScheduleRequest(id));
      return StatusCode(Schedule?.Success == true ? 200 : 500, Schedule?.Message);
    }

    [HttpPut]
    [Produces("application/json")]
    public async Task<ObjectResult> CreateSchedule([FromBody] CreateScheduleRequest model)
    {
      if (ModelState.IsValid)
      {
        var response = await Mediator.Send(model);
        return Ok(response?.Model);
      }
      else
      {
        return StatusCode(400, ModelState.Values);
      }
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<ObjectResult> UpdateSchedule([FromBody] UpdateScheduleRequest model)
    {
      if (ModelState.IsValid)
      {
        var response = await Mediator.Send(model);
        return Ok(response?.Model);
      }
      else
      {
        return StatusCode(400, ModelState.Values);
      }
    }
  }
}
