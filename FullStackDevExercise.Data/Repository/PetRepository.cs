using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Data.Interfaces;

namespace FullStackDevExercise.Data.Repository
{
  public class PetRepository : BaseRepository<PetEntity, PetModel>, IPetRepository
    {
        public PetRepository(DoLittleDbContext context, IMapperExtension mapper) : base(context, mapper)
        {
        }
    }
}
