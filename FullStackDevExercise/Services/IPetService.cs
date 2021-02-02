using FullStackDevExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services
{
  public interface IPetService
  {
    Task<Pet> Add(Pet pet);

    Task<Pet> Update(int id, Pet pet);
    Task Delete(int id);
    Task<Pet> GetById(int id);
    Task<IEnumerable<Pet>> GetAll();

  }
}
