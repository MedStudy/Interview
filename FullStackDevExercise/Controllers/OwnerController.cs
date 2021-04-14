using FSDExercise.Common.Models;
using FSDExercise.DB;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]")]
  public class OwnerController : ControllerBase
  {
    private readonly FSDExerciseDBContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OwnerController> _logger;
    private readonly IOwnerService _ownerService;
    private readonly IPetService _petService;
    private readonly IAppointmentService _appointmentService;
    public OwnerController(FSDExerciseDBContext dbContext,
      IConfiguration configuration,
      ILogger<OwnerController> logger,
      IOwnerService ownerService,
      IPetService petService,
      IAppointmentService appointmentService)
    {
      _dbContext = dbContext;
      _configuration = configuration;
      _logger = logger;
      _ownerService = ownerService;
      _petService = petService;
      _appointmentService = appointmentService;
    }



    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAll()
    {
      var result = await _ownerService.GetAllOwners();
      if (result != null)
        return Ok(result);

      return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var result = await _ownerService.GetOwner(id);
      if (result != null)
        return Ok(result);

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OwnerRequest ownerRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest("Please verify the input provided");

      var result = await _ownerService.AddOwner(ownerRequest);
      if (result.isSuccess)
        return Ok("Ownser added successfully.");

      return UnprocessableEntity(result.ErrorMessage);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, OwnerRequest ownerRequest)
    {
      var updateResponse = await _ownerService.UpdateOwner(id, ownerRequest);
      if (updateResponse.result.isSuccess)
        return Ok(updateResponse.owner);

      return UnprocessableEntity(updateResponse.result.ErrorMessage);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _ownerService.DeleteOwner(id);
      if (result.isSuccess)
        return Ok("Ownser deleted successfully.");

      return UnprocessableEntity(result.ErrorMessage);
    }

    [HttpPost]
    [Route("{ownerId}/Pet/add")]
    public async Task<IActionResult> AddPet(int ownerId, [FromBody] PetRequest petRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest("Please verify the input provided");

      var result = await _petService.AddPet(ownerId,petRequest);
      if (result.isSuccess)
        return Ok("Pet added successfully.");

      return UnprocessableEntity(result.ErrorMessage);
    }

    [HttpPost]
    [Route("{ownerId}/{petId}/getAppointment")]
    public async Task<IActionResult> GetAppointment(int ownerId,int petId,[FromBody] AppointmentRequest appointmentRequest)
    {
      if (!ModelState.IsValid)
        return BadRequest("Please verify the input provided");

      var result = await _appointmentService.RequestAppointment(ownerId,petId,appointmentRequest);
      if (result.isSuccess)
        return Ok("Appointment Confirmed.");

      return UnprocessableEntity(result.ErrorMessage);
    }
  }
}
