using FullStackDevExercise.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ownersController : ControllerBase
  {
    Iowner _owner;
    public ownersController(Iowner owner)
    {
      _owner = owner;
    }

    [HttpGet]
    public IActionResult getAll()
    {
      var result = _owner.getAllowners();
      return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult get(string id)
    {
      var result = _owner.getowners(id);
      return Ok(result);
    }

    [HttpPost]
    public IActionResult create(owners data)
    {
      var result = _owner.createowner(data);
      return Ok(result);
    }
    [HttpPut]
    public IActionResult update(owners data)
    {
      var result = _owner.updateowner(data);
      return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult delete(string id)
    {
      var result = _owner.deleteowner(id);
      return Ok(result);
    }
  }
}
