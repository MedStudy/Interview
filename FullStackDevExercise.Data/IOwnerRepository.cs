using FullStackDevExercise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackDevExercise.Data
{
  public interface IOwnerRepository
  {
    Owner GetById(int id);
    IQueryable<Owner> GetAll();
    int Save(Owner owner);
    int Delete(int id);
  }
}
