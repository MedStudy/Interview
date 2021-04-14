using FSDExercise.Core.Contracts;
using FSDExercise.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Core.Implementations
{
  public abstract class BaseRepository<T> : IRepository<T> where T : class
  {
    private readonly FSDExerciseDBContext _dbContext;
    public BaseRepository(FSDExerciseDBContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task Add(T entity)
    {
      await _dbContext.BeginTransaction();
      await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.Commit();
    }

    public async Task Delete(T entity)
    {
      await _dbContext.BeginTransaction();
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.Commit();
    }

    public async Task<T> Get(int id)
    {
      //return await _dbContext.Set<T>().FindAsync(id);
      var mbSet = _dbContext.Set<T>().AsQueryable();
      //mbSet = mbSet.IgnoreAutoIncludes();
      return mbSet.AsNoTracking().FirstOrDefault();

    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return _dbContext.Set<T>().ToList();
    }

    public async Task Update(T entity)
    {
      _dbContext.Entry<T>(entity).State = EntityState.Modified;
    }
  }
}
