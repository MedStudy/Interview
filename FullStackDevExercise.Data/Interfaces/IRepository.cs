using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FullStackDevExercise.Data.Interfaces
{
  public interface IRepository<TEntity, TModel> : IDisposable
          where TEntity : class
    {
        Task<IEnumerable<TModel>> GetList();
        Task<TModel> GetByIdAsync(long id);
        Task<bool> CreateAsync(TModel model);
        Task<bool> Update(TModel model, long id);
        Task<bool> Delete(long id);

  }
}
