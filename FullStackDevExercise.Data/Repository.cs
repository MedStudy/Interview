using FullStackDevExercise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackDevExercise.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
  {

    private readonly DataContext context;
    public Repository(DataContext Context)
    {
      context = Context;
    }
    public T GetById(int id)
    {
      return context.Set<T>().Find(id);
    }

    public IReadOnlyList<T> GetAll()
    {
      return context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
      context.Set<T>().Add(entity);
      context.SaveChanges();
    }

    public void Update(T entity)
    {
      context.Set<T>().Attach(entity);
      context.Entry(entity).State = EntityState.Modified;
      context.SaveChanges();
    }

    public void Delete(T entity)
    {
      context.Set<T>().Remove(entity);
      context.SaveChanges();
    }
  }
}
