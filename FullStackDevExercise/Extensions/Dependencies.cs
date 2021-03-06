using FullStackDevExercise.Contracts;
using FullStackDevExercise.DataAccess;
using FullStackDevExercise.Services;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class Dependencies
  {
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
      services.AddSingleton<IIdentityValueGenerator, IdentityValueGenerator>()
                 .AddSingleton<IBootstrapper, Bootstrapper>();
      return services;
    }
  }
}
