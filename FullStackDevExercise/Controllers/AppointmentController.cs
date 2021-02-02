using FullStackDevExercise.Models;
using FullStackDevExercise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [Route("api/appointments")]
  [ApiController]
  public class AppointmentController: ControllerBase
  {
    /// <summary>
    /// Business logic service instance.
    /// </summary>
    private readonly IAppointmentService service;

    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<AppointmentController> logger;

    public MedStudyContext DbContext { get; }

    public AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger)
    {
      this.service = service;
      this.logger = logger;
    }

    /// <summary>
    /// Creates a new Appointment.
    /// </summary>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Appointment))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Appointment>> Post([FromBody] Appointment appointment)
    {
      return this.Ok(await this.service.Add(appointment).ConfigureAwait(false));
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    [HttpPut("{id}")]
    [Produces(typeof(Appointment))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Appointment>> Put(int id, [FromBody] Appointment appointment)
    {
      return this.Ok(await this.service.Update(id, appointment).ConfigureAwait(false));
    }

    /// <summary>
    /// Deletes an existing appointment.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult> Delete(int id)
    {
      await this.service.Delete(id).ConfigureAwait(false);
      return this.NoContent();
    }


    /// <summary>
    /// Gets all appointments.
    /// </summary>
    [HttpGet]
    [Produces(typeof(IEnumerable<Appointment>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
    {
      return this.Ok(await this.service.GetAll().ConfigureAwait(false));
    }

    /// <summary>
    /// Gets appointment by Id.
    /// </summary>
    [HttpGet("{id}", Name = "GetAppointment")]
    [Produces(typeof(Appointment))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Appointment>> GetById(int id)
    {
      return this.Ok(await this.service.GetById(id).ConfigureAwait(false));
    }
  }
}
