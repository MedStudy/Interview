using FullStackDevExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services
{
  public interface IOwnerService
  {
    Task<IEnumerable<Owner>> GetAll();

    Task<Owner> Add(Owner owner);

    Task<Owner> Update(int id, Owner user);
    Task Delete(int id);
    Task<Owner> GetById(int id);

  }
}
