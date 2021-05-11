using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;

namespace FullStackDevExercise.Data.Interfaces
{
    public interface IPetRepository : IRepository<PetEntity, PetModel>
    {
      
    }
}
