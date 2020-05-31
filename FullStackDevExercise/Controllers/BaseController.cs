using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Business;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDevExercise.Controllers
{
  public class BaseController : Controller
  {
    public BusinessLayer businessLayer;
    public BaseController()
    {
      businessLayer = new BusinessLayer();
    }
  }
}
