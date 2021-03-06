using System;
using System.Threading.Tasks;
using FullStackDevExercise.DataAccess;

namespace FullStackDevExercise.Contracts
{
  public interface IIdentityValueGenerator
  {
    public Task<long> WithContext(DolittleContext context, Func<DolittleContext, long> accessor);
  }
}
