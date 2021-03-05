using System;
using System.Threading.Tasks;
using FullStackDevExercise.Contracts;
using FullStackDevExercise.DataAccess;

namespace FullStackDevExercise.Services
{
  public class IdentityValueGenerator : IIdentityValueGenerator
  {
    private static readonly object _syncRoot = new object();
    public Task<long> WithContext(dolittleContext context, Func<dolittleContext, long> accessor)
    {
      long id = 1;
      try
      {
        lock (_syncRoot)
        {
          id = accessor(context);
        }
        return Task.FromResult(id + 1);
      }
      catch
      {
        return Task.FromResult(id);
      }
    }
  }
}
