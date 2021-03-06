using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Owners;
using FullStackDevExercise.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class OwnerController : BaseController
  {
    private readonly IMapper _mapper;

    public OwnerController(IMediator mediator, IMapper mapper) : base(mediator)
    {
      _mapper = mapper;
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
    public async Task<ObjectResult> SaveOwner( [FromBody]  OwnerViewModel model)
    {
      if (ModelState.IsValid && model != null)
      {
        var response = await Mediator.Send(new SaveOwnerRequest(_mapper.Map<OwnerModel>( model) ));
        return Ok( response?.Model);
      }
      else
      {
        return StatusCode(400, ModelState.Values);
      }
    }
  }
}
