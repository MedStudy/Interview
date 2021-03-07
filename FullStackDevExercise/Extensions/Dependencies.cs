using FullStackDevExercise.Contracts;
using FullStackDevExercise.DataAccess;
using FullStackDevExercise.Services;

namespace Microsoft.Extensions.DependencyInjection
{
  /// <summary>
  /// Extension method to group all our app specific dependency registrations into once place.
  /// </summary>
  public static class Dependencies
  {
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
      services.AddSingleton<IIdentityValueGenerator, IdentityValueGenerator>()
                 .AddSingleton<IBootstrapper, Bootstrapper>()
                 .AddSingleton<IDistributedLock, MockDistributedLock>();
      return services;
    }
  }
}
