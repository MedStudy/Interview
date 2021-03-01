using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OwnerController : ControllerBase
  {
    // GET: api/<OwnerController>
    [HttpGet]
    public IActionResult Get()
    {

      return Ok();
    }

    // GET api/<OwnerController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<OwnerController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<OwnerController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OwnerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
