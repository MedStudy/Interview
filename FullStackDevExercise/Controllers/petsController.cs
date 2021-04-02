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
  public class petsController : ControllerBase
  {
    Ipets _pets;
    public petsController(Ipets pets)
    {
      _pets = pets;
    }

    [HttpGet]
    public IActionResult getAll()
    {
      var result = _pets.getAllpets();
      return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult get(string id)
    {
      var result = _pets.getpets(id);
      return Ok(result);
    }

    [HttpPost]
    public IActionResult create(Pets data)
    {
      var result = _pets.createpet(data);
      return Ok(result);
    }
    [HttpPut]
    public IActionResult update(Pets data)
    {
      var result = _pets.updatepet(data);
      return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult delete(string id)
    {
      var result = _pets.deletepet(id);
      return Ok(result);
    }
  }
}
