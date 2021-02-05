using FullStackDevExercise.DAL.DBContext;
using FullStackDevExercise.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.DAL.Repository
{
  public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
  {
    protected readonly MainDbContext _dbContext;

    public BaseRepository(MainDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public void Dispose()
    {
      if (_dbContext != null)
        _dbContext.Dispose();
    }

    public abstract IEnumerable<TEntity> GetAsync();
    public abstract TEntity GetAsync(long id);

    public abstract Task<long> InsertAsync(TEntity data);

    public abstract Task<bool> UpdateAsync(TEntity data);

    public abstract Task<long> DeleteAsync(long id);
  }
}
