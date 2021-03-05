using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]")]
  public abstract class BaseController : Controller
  {
    protected BaseController(IMediator mediator)
    {
      Mediator = mediator;
    }

    public IMediator Mediator { get; }
  }
}
