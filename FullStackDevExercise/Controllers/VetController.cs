using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Vets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class VetController : BaseController
  {
    public VetController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IEnumerable<VetModel>> GetAvailability([FromQuery] string dateTime)
    {
      var vets = await Mediator.Send(new ListVetAvailabilityRequest(dateTime));
      return vets?.Models ?? Enumerable.Empty<VetModel>();
    }
  }
}
