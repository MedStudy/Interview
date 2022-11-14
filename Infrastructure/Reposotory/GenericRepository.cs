using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repository
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    protected ApplicationDbContext context;
    internal DbSet<T> dbSet;
   // public readonly ILogger _logger;

    public GenericRepository(
        ApplicationDbContext context
       )
    {
      this.context = context;
      this.dbSet = context.Set<T>();
      //_logger = logger;
    }

    

   
    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
      return await dbSet.Where(predicate).ToListAsync();
    }

    public virtual Task<bool> Upsert(T entity)
    {
      throw new NotImplementedException();
    }

   


      IQueryable<T> IGenericRepository<T>.FindByCondition(Expression<Func<T, bool>> predicate)
    {
      return  dbSet.Where(predicate);
    }
   IQueryable<T> IGenericRepository<T>.FindAll()
    {
      return  dbSet.AsNoTracking();
    }


    void IGenericRepository<T>.Create(T entity)
    {
      dbSet.Add(entity);
      
    }

    void IGenericRepository<T>.Update(T entity)
    {
      throw new NotImplementedException();
    }

    void IGenericRepository<T>.Delete(T entity)
    {
      throw new NotImplementedException();
    }
  }
}
