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
  public class OwnerService: IOwnerService
  {
    /// <summary>
    /// Logger for logging events.
    /// </summary>
    private readonly ILogger<OwnerService> Logger;

    /// <summary>
    /// Database Context.
    /// </summary>
    private readonly MedStudyContext Context;

    public OwnerService(MedStudyContext context, ILogger<OwnerService> logger)
    {
      this.Context = context;
      this.Logger = logger;
    }

    public async Task<Owner> Add(Owner owner)
    {
      if (owner.Id != 0)
      {
        throw new InvalidDataException("To add an owner, Id should be set to zero.");
      }

      this.Context.Add<Owner>(owner); // adds the owner to the DbSet in memory
      this.Context.SaveChanges(); // commits the changes to the database
      var response = await Task.FromResult(this.Context.Owners.OrderByDescending(owner => owner.Id).First());
      return response;
    }

    public async Task<Owner> Update(int id, Owner owner)
    {
      var response = await Task.FromResult(this.Context.Owners.Single(user => user.Id == id));
      if (response is null)
      {
        throw new Exception("Specified Owner does not exist.");
      }
      else
      {
        response.First_Name = owner.First_Name;
        response.Last_Name = owner.Last_Name;

        this.Context.SaveChanges(); // commits the changes to the database
      }

      return response;
    }
    public async Task Delete(int id)
    {
      var response = await Task.FromResult(this.Context.Owners.Single(user => user.Id == id));
      if (response is null)
      {
        throw new Exception("Specified User does not exist.");
      }
      else
      {
        this.Context.Owners.Remove(response);
        this.Context.SaveChanges(); // commits the changes to the database
      }
    }

    public async Task<Owner> GetById(int id)
    {
      var response = await Task.FromResult(this.Context.Owners.Single(user => user.Id == id)).ConfigureAwait(false);
      if (response is null)
      {
        throw new Exception("Specified User does not exist.");
      }

      return response;
    }

    public async Task<IEnumerable<Owner>> GetAll()
    {
      var response = await (from owners in Context.Owners
                            select owners).ToListAsync().ConfigureAwait(false);

      return response;
    }
  }
}
