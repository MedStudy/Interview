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
  [Route("api/owners")]
  [ApiController]
  public class OwnerController: ControllerBase
  {
    /// <summary>
    /// Business logic service instance.
    /// </summary>
    private readonly IOwnerService service;

    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<OwnerController> logger;

    public MedStudyContext DbContext { get; }

    public OwnerController(IOwnerService service, ILogger<OwnerController> logger)
    {
      this.service = service;
      this.logger = logger;
    }

    /// <summary>
    /// Creates a new owner.
    /// </summary>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Owner))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Owner>> Post([FromBody] Owner owner)
    {
      return this.Ok(await this.service.Add(owner).ConfigureAwait(false));
    }

    /// <summary>
    /// Updates an existing owner.
    /// </summary>
    [HttpPut("{id}")]
    [Produces(typeof(Owner))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Owner>> Put(int id, [FromBody] Owner owner)
    {
      return this.Ok(await this.service.Update(id, owner).ConfigureAwait(false));
    }

    /// <summary>
    /// Deletes an existing owner.
    /// </summary>
    /// <param name="id">Id of owner to be deleted. </param>
    /// <returns> No Content.</returns>
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
    /// Gets all owners.
    /// </summary>
    [HttpGet]
    [Produces(typeof(IEnumerable<Owner>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<IEnumerable<Owner>>> GetAll()
    {
      return this.Ok(await this.service.GetAll().ConfigureAwait(false));
    }

    /// <summary>
    /// Gets owner by Id.
    /// </summary>
    [HttpGet("{id}", Name = "GetOwner")]
    [Produces(typeof(Owner))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Owner>> GetById(int id)
    {
      return this.Ok(await this.service.GetById(id).ConfigureAwait(false));
    }
  }
}
