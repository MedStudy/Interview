using FullStackDevExercise.Data.Interfaces;
using FullStackDevExercise.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise.Data
{
  public static class DataDependencies
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddDbContext<DoLittleDbContext>(ServiceLifetime.Transient);
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        }
    }
}
