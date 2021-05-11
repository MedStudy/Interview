using FullStackDevExercise.Common.Interfaces;
using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Data.Repository
{
  public abstract class BaseRepository<TEntity, TModel> : IRepository<TEntity, TModel> where
        TEntity : EntityBase, new()
        where TModel : ModelBase, new()
    {
        private readonly DoLittleDbContext _context;
        internal readonly IMapperExtension _mapper;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(DoLittleDbContext context, IMapperExtension mapper)
        {
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TModel> GetByIdAsync(long id)
        {
          var x = await _dbSet.FindAsync(id);

          if (x == null)
          {
            return null;
          }

          return _mapper.MapObjectTo<TModel>(x);
        }

        public async Task<bool> CreateAsync(TModel model)
        {
            try
            {
              TEntity newEntity = _mapper.MapObjectTo<TEntity>(model);
              await _dbSet.AddAsync(newEntity);
              await _context.SaveChangesAsync();
              return newEntity.Id > 0 ? true : false;
            }
            catch(Exception ex)
            {
              return false;
            }
        }

        public async Task<bool> Delete(long id)
        {
            TEntity entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
              return false;
            }
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TModel>> GetList()
        {
          var x = await _context.Set<TEntity>().AsNoTracking().ToListAsync(); 
          return _mapper.MapListTo<TModel, TEntity>(x);
        }

        public async Task<bool> Update(TModel model, long id)
        {
            try
            {
              TEntity newEntity = _mapper.MapObjectTo<TEntity>(model);
              TEntity entity = await _dbSet.FindAsync(id);
              newEntity.Id = entity.Id;
              _context.Entry(entity).CurrentValues
                                        .SetValues(newEntity);
              await _context.SaveChangesAsync();

              return true;
            }
            catch(Exception ex)
            {
              return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
