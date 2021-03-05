using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Pets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class PetController : BaseController
  {
    public PetController(IMediator mediator) : base(mediator)
    {
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
    public async Task<PetModel> SavePet([FromBody] PetModel model)
    {
      var response = await Mediator.Send(new SavePetRequest(model));
      return response.Model;
    }
  }
}
