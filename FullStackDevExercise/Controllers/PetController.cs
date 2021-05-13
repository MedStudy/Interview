using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.ViewModels;
using FullStackDevExercise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace FullStackDevExercise.Controllers
{
      [ApiController]
      [Route("api/pets")]
      public class PetController : Controller
      {
          private readonly IPetService _petService;
          private readonly IMapperExtension _mapper;

          public PetController(IPetService petService, IMapperExtension mapper)
          {
              _petService = petService;
              _mapper = mapper;
          }

          [HttpGet("GetAllPets")]
          public async Task<ActionResult> GetAll()
          {
            return Ok(await _petService.GetPetListAsync());
          }

          [HttpGet("GetPetById/{id}")]
          public async Task<ActionResult<PetViewModel>> GetPetById(long id)
          {
            var pet = await _petService.GetPetById(id);
            if (pet == null) return NotFound();
            return Ok(pet);
          }

          [HttpPost("CreatePet")]
          public async Task<ActionResult<bool>> CreatePetAsync(PetViewModel createPet)
          {
              PetModel pet = _mapper.MapObjectTo<PetModel>(createPet);
              bool isCreated = await _petService.CreatePetAsync(pet);
              return isCreated ? Created(Url.Action(nameof(GetPetById), new { id = pet.Id }), _mapper.MapObjectTo<PetViewModel>(pet)) as ActionResult : BadRequest() as ActionResult;
          }

          [HttpPut("UpdatePet/{id}")]
          public async Task<ActionResult<OwnerModel>> UpdatePetAsync(long id, PetViewModel updatePet)
          {
            PetModel pet = _mapper.MapObjectTo<PetModel>(updatePet);
            bool isSaved = await _petService.UpdatePetAsync(id, pet);
            if (!isSaved) return NotFound();
            return Ok(isSaved);
          }

          [HttpDelete("DeletePet/{id}")]
          public async Task<ActionResult> DeletePetAsync(long id)
          {
            bool isDeleted = await _petService.DeletePetAsync(id);
            return isDeleted ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
          }
      }
}
