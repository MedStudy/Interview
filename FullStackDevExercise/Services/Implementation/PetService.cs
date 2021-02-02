using FullStackDevExercise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Implementation
{
  public class PetService: IPetService
  {
    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<PetService> Logger;

    /// <summary>
    /// Database Context.
    /// </summary>
    private readonly MedStudyContext Context;

    public PetService(MedStudyContext context, ILogger<PetService> logger)
    {
      this.Context = context;
      this.Logger = logger;
    }

    public async Task<Pet> Add(Pet pet)
    {
      if (pet.Id != 0)
      {
        throw new InvalidDataException("To add an pet, Id should be set to zero.");
      }
      var owner = await Task.FromResult(this.Context.Owners.Single(user => user.Id == pet.Owner_Id)).ConfigureAwait(false);

      if(owner is null)
      {
        throw new Exception("No Owner with this owner_id exists");
      }
      else
      {
        this.Context.Add<Pet>(pet); // adds the owner to the DbSet in memory
        this.Context.SaveChanges(); // commits the changes to the database
        var response = await Task.FromResult(this.Context.Pets.OrderByDescending(pet => pet.Id).First());

        return response;
      }
      
    }

    public async Task<Pet> Update(int id, Pet pet)
    {
      var response = await Task.FromResult(this.Context.Pets.Single(x => x.Id == id));
      if (response is null)
      {
        throw new Exception("Specified Pet does not exist.");
      }
      else
      {
        response.Owner_Id = pet.Owner_Id;
        response.Name = pet.Name;
        response.Age = pet.Age;
        response.Type = pet.Type;

        this.Context.SaveChanges(); // commits the changes to the database
      }

      return response;
    }

    public async Task Delete(int id)
    {
      var response = await Task.FromResult(this.Context.Pets.Single(user => user.Id == id));
      if (response is null)
      {
        throw new Exception("Specified Pet does not exist.");
      }
      else
      {
        this.Context.Pets.Remove(response);
        this.Context.SaveChanges(); // commits the changes to the database
      }
    }

    public async Task<Pet> GetById(int id)
    {
      var response = await Task.FromResult(this.Context.Pets.Single(user => user.Id == id)).ConfigureAwait(false);
      if (response is null)
      {
        throw new Exception("Specified Pet does not exist.");
      }

      return response;
    }

    public async Task<IEnumerable<Pet>> GetAll()
    {
      var response = await (from pets in Context.Pets
                            select pets).ToListAsync().ConfigureAwait(false);

      return response;
    }
  }
}
