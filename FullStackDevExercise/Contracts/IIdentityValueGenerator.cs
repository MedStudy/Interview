using System;
using System.Threading.Tasks;
using FullStackDevExercise.DataAccess;

namespace FullStackDevExercise.Contracts
{
  /// <summary>
  ///The tables provided with this excerise did not have identity columns specified.  I could have dropped the tables and added them with identity specification, but I chose to leave things as is and create a
  ///naive identity value generator.
  /// </summary>
  public interface IIdentityValueGenerator
  {
    public Task<long> WithContext(DolittleContext context, Func<DolittleContext, long> accessor);
  }
}
