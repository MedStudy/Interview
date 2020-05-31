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
  public class PetController : BaseController
  {
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult GetPets(int id)
    {
      return Json(businessLayer.GetPets(id));
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult DeletePet(int id)
    {
      return Json(businessLayer.DeletePet(id));
    }

    [HttpPost]
    public ActionResult AddUpdatePet([FromBody] Pet pet)
    {
      return Json(businessLayer.AddUpdatePet(pet));
    }
  }
}
