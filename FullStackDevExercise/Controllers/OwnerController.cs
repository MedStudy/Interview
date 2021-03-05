using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Owners;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class OwnerController : BaseController
  {
    public OwnerController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IEnumerable<OwnerModel>> GetOwners()
    {
      var owners = await Mediator.Send(new ListOwnersRequest());
      return owners?.Models ?? Enumerable.Empty<OwnerModel>();
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<OwnerModel> GetOwner([FromRoute] long id)
    {
      var owner = await Mediator.Send(new GetOwnerRequest(id));
      return owner?.Model;
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    public async Task<ObjectResult> DeleteOwner([FromRoute] long id)
    {
      var owner = await Mediator.Send(new RemoveOwnerRequest(id));
      return StatusCode(owner?.Success == true ? 200 : 500, owner?.Message);
    }
    [HttpPost]
    [Produces("application/json")]
    public async Task<OwnerModel> SaveOwner( [FromBody]  OwnerModel model)
    {
       var response = await Mediator.Send(new SaveOwnerRequest(model));
      return response?.Model;
    }
  }
}
