using FullStackDevExercise.Services;
using FullStackDevExercise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [ApiController]
  [Route("api/owners")]
  public class OwnersController : BaseController
  {
    private readonly IPetOwnerService _petOwnerService;

    public OwnersController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
      _petOwnerService = GetService<IPetOwnerService>();
    }

    [HttpGet]
    public ActionResult Get()
    {
      var result = _petOwnerService.GetOwnersAsync();
      return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<OwnerViewModel> Get(long id)
    {
      var result = _petOwnerService.GetOwnerAsync(id);

      if (result == null) return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OwnerViewModel>> Post(OwnerViewModel model)
    {
      model.Id = 0;
      var isSuccess = await _petOwnerService.SaveOwnerAsync(model);

      return isSuccess ? Created(Url.Action(nameof(Get), new { id = model.Id }), model) as ActionResult : BadRequest() as ActionResult;
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<OwnerViewModel>> Put(long id, OwnerViewModel model)
    {
      model.Id = id;
      var isSaved = await _petOwnerService.SaveOwnerAsync(model);

      if (!isSaved) return NotFound();

      return Ok(isSaved);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
      bool deleteOk = await _petOwnerService.DeleteOwnerAsync(id);

      return deleteOk ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
    }
  }
}
