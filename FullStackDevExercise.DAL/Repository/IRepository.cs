using FullStackDevExercise.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.DAL.Repository
{
  public interface IRepository<TEntity> where TEntity : class, IEntity
  {
    Task<long> DeleteAsync(long id);
    Task<TEntity> GetAsync(long id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<long> InsertAsync(TEntity data);
    Task<bool> UpdateAsync(TEntity data);
  }
}
