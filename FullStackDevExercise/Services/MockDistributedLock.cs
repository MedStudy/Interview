using System.Threading.Tasks;
using FullStackDevExercise.Contracts;

namespace FullStackDevExercise.Services
{
  /// <summary>
  /// this class actually does nothing.  It exists to illustrate how a distributed lock could be used.
  ///
  /// In a situation where you could have many concurrent requests for a single resource (appointment time) by owners, we need a mechanism to synchronize writes to the database.
  /// </summary>
  /// <seealso cref="FullStackDevExercise.Contracts.IDistributedLock" />
  public class MockDistributedLock : IDistributedLock
  {
    public Task AcquireAsync(string key)
    {
      return Task.CompletedTask;
    }

    public Task ReleaseAsync(string key)
    {
      return Task.CompletedTask;
    }
  }
}
