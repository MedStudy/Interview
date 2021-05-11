using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Data.Interfaces;

namespace FullStackDevExercise.Data.Repository
{
  public class OwnerRepository : BaseRepository<OwnerEntity, OwnerModel>, IOwnerRepository
  {
    public OwnerRepository(DoLittleDbContext context, IMapperExtension mapper) : base(context, mapper)
    {
    }
  }
}
