using FullStackDevExercise.Common.Extensions;
using FullStackDevExercise.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise.Common
{
  public static class CommonDependencies
    {
        public static void Initialize(IServiceCollection services)
        {
           RegisterExtensions(services);
        }

        private static void RegisterExtensions(IServiceCollection services)
        {
           services.AddTransient<IMapperExtension, MapperExtension>();
        }
    }
}
