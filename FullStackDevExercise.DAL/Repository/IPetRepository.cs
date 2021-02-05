using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;

namespace FullStackDevExercise.DAL.Repository
{
  public interface IPetRepository : IRepository<PetEntity>
  {
    IList<PetEntity> GetByOwnerIdAsync(long ownerId);
  }
}
