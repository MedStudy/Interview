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
  [Route("api/pets")]
  [ApiController]
  public class PetController: ControllerBase
  {
    /// <summary>
    /// Business logic service instance.
    /// </summary>
    private readonly IPetService service;

    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<PetController> logger;

    public MedStudyContext DbContext { get; }

    public PetController(IPetService service, ILogger<PetController> logger)
    {
      this.service = service;
      this.logger = logger;
    }

    /// <summary>
    /// Creates a new pet.
    /// </summary>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Pet))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Pet>> Post([FromBody] Pet pet)
    {
      return this.Ok(await this.service.Add(pet).ConfigureAwait(false));
    }

    /// <summary>
    /// Updates an existing pet.
    /// </summary>
    [HttpPut("{id}")]
    [Produces(typeof(Pet))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Pet>> Put(int id, [FromBody] Pet pet)
    {
      return this.Ok(await this.service.Update(id, pet).ConfigureAwait(false));
    }

    /// <summary>
    /// Deletes an existing pet.
    /// </summary>
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
    /// Gets all pets.
    /// </summary>
    [HttpGet]
    [Produces(typeof(IEnumerable<Pet>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<IEnumerable<Pet>>> GetAll()
    {
      return this.Ok(await this.service.GetAll().ConfigureAwait(false));
    }

    /// <summary>
    /// Gets pet by Id.
    /// </summary>
    [HttpGet("{id}", Name = "GetPet")]
    [Produces(typeof(Pet))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.PreconditionFailed)]
    public async Task<ActionResult<Pet>> GetById(int id)
    {
      return this.Ok(await this.service.GetById(id).ConfigureAwait(false));
    }
  }
}
