using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.DAL.Repository
{
  public interface IRepository<TEntity> where TEntity : class, IEntity
  {
    Task<long> DeleteAsync(long id);
    TEntity GetAsync(long id);
    IEnumerable<TEntity> GetAsync();
    Task<long> InsertAsync(TEntity data);
    Task<bool> UpdateAsync(TEntity data);
  }
}
