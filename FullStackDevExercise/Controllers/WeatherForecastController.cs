using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSDExercise.Common.Models;
using FSDExercise.DB;
using FSDExercise.DB.Entities;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FullStackDevExercise.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly FSDExerciseDBContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOwnerService _ownerService;
    public WeatherForecastController(FSDExerciseDBContext dbContext,
      IConfiguration configuration,
      ILogger<WeatherForecastController> logger,
      IOwnerService ownerService)
    {
      _dbContext = dbContext;
      _configuration = configuration;
      _logger = logger;
      _ownerService = ownerService;
    }

    private static readonly string[] Summaries = new[]
    {
       "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    

    //public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //{
    //  _logger = logger;
    //}

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpPost]
    public async Task<Owner> Post()
    {
      //_dbContext.Owners.Add(new Owner { first_name = "john", last_name = "dey" });
      //await _dbContext.SaveChangesAsync();

      //await _dbContext.BeginTransaction();
      //_dbContext.Owners.Add(new Owner { first_name = "Ravi", last_name = "Kumar" });
      //await _dbContext.Commit();

      await _ownerService.AddOwner(new OwnerRequest { FirstName = "Ravi", LastName = "Kumar" });
      return null;
    }
  }  
}
