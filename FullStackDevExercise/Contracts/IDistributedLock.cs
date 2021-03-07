using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Contracts
{
  /// <summary>
  /// Defines an abstraction for a distributed lock.
  /// </summary>
  public interface IDistributedLock
  {

    Task AcquireAsync(string key);
    Task ReleaseAsync(string key);
  }
}
