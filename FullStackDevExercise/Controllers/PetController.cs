using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Pets;
using FullStackDevExercise.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class PetController : BaseController
  {
    private readonly IMapper _mapper;

    public PetController(IMediator mediator, IMapper mapper) : base(mediator)
    {
      _mapper = mapper;
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IEnumerable<PetModel>> GetPets()
    {
      var pets = await Mediator.Send(new ListPetRequest());
      return pets?.Models ?? Enumerable.Empty<PetModel>();
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<PetModel> GetPet([FromRoute] int id)
    {
      var pet = await Mediator.Send(new GetPetRequest(id));
      return pet?.Model;
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<ObjectResult> DeletePet([FromRoute] int id)
    {
      var pet = await Mediator.Send(new RemovePetRequest(id));
      return StatusCode(pet?.Success == true ? 200 : 500, pet?.Message);
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<ObjectResult> SavePet([FromBody] PetViewModel model)
    {


      if (ModelState.IsValid && model != null)
      {
        var petModel = _mapper.Map<PetModel>(model);
        petModel.Owner = new OwnerModel
        {
          Id = model.OwnerId
        };
        var response = await Mediator.Send(new SavePetRequest(petModel));
        return Ok(response.Model);
      }
      else
      {
        return StatusCode(400, ModelState.Values);
      }
    }
  }
}
