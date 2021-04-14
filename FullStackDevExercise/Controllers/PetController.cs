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
  public class PetController : ControllerBase
  {
    private readonly FSDExerciseDBContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly ILogger<PetController> _logger;
    private readonly IPetService _petService;
    public PetController(FSDExerciseDBContext dbContext,
      IConfiguration configuration,
      ILogger<PetController> logger,
      IPetService petService)
    {
      _dbContext = dbContext;
      _configuration = configuration;
      _logger = logger;
      _petService = petService;
    }

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAll()
    {
      var pets = await _petService.GetAllPets();
      if (pets is null)
        return NotFound("No pets exists");

      return Ok(pets);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var pet = await _petService.GetPet(id);
      if (pet is null)
        return NotFound("Pet doesn't exists"); ;

      return Ok(pet);
    }

    //[HttpPost]    
    //public async Task<IActionResult> Post([FromBody] PetRequest petRequest)
    //{
    //  if (!ModelState.IsValid)
    //    return BadRequest("Please verify the input provided");

    //  var result = await _petService.AddPet(petRequest);
    //  if (result.isSuccess)
    //    return Ok("Pet added successfully.");

    //  return UnprocessableEntity(result.ErrorMessage);
    //}

    [HttpPut]
    [Route("{petId}")]
    public async Task<IActionResult> Put(int petId, PetUpdateRequest petRequest)
    {
      var updateResponse = await _petService.UpdatePet(petId, petRequest);
      if (updateResponse.Item1.isSuccess)
        return Ok(updateResponse.Item2);

      return UnprocessableEntity(updateResponse.Item1.ErrorMessage);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _petService.DeletePet(id);
      if (result.isSuccess)
        return Ok("Pet deleted successfully.");

      return UnprocessableEntity(result.ErrorMessage);
    }
  }
}
