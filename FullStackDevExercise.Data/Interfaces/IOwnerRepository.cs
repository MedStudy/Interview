using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Data.Interfaces
{
    public interface IOwnerRepository : IRepository<OwnerEntity, OwnerModel>
    {
          Task<List<OwnerModel>> GetOwnerList();
    }
}
