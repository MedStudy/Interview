using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Entities;
using FullStackDevExercise.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]/[action]")]
  public class OwnerController : BaseController
  {
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult GetOwners(int id)
    {
      return Json(businessLayer.GetOwners(id));
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult DeleteOwner(int id)
    {
      return Json(businessLayer.DeleteOwner(id));
    }

    [HttpPost]
    public ActionResult AddUpdateOwner([FromBody] Owner owner)
    {
      return Json(businessLayer.AddUpdateOwner(owner));
    }
  }
}
