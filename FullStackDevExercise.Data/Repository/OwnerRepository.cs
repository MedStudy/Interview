using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using FullStackDevExercise.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FullStackDevExercise.Data.Repository
{
  public class OwnerRepository : BaseRepository<OwnerEntity, OwnerModel>, IOwnerRepository
  {
    public OwnerRepository(DoLittleDbContext context, IMapperExtension mapper) : base(context, mapper)
    {
    }

      public async Task<List<OwnerModel>> GetOwnerList()
      {
          return _mapper.MapListTo<OwnerModel, OwnerEntity>(await _context.Set<OwnerEntity>().AsNoTracking().Include(x => x.Pets).ToListAsync());
      }
  }
}
