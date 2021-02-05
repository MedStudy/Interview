using FullStackDevExercise.DAL.DBContext;
using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.DAL.Repository
{
  public class OwnerRepository : BaseRepository<OwnerEntity>, IOwnerRepository
  {
    public OwnerRepository(MainDbContext dbContext) : base(dbContext)
    {

    }

    public override Task<long> DeleteAsync(long id)
    {
      throw new System.NotImplementedException();
    }

    public override Task<IEnumerable<OwnerEntity>> GetAsync()
    {
      throw new System.NotImplementedException();
    }

    public override Task<OwnerEntity> GetAsync(long id)
    {
      throw new System.NotImplementedException();
    }

    public override async Task<long> InsertAsync(OwnerEntity data)
    {
      if (data == null) return 0;
      _dbContext.Set<OwnerEntity>().Add(data);
      await _dbContext.SaveChangesAsync();
      var result = data.id;
      return result;
    }

    public override async Task<bool> UpdateAsync(OwnerEntity data)
    {
      if (data == null) return false;
      var owner = _dbContext.Owners.Find(data.id);
      if (owner != null)
      {
        owner.first_name = data.first_name;
        owner.last_name = data.last_name;
      }
      await _dbContext.SaveChangesAsync();
      return true;
    }
  }
}
