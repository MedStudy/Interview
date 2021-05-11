using FullStackDevExercise.Services.Interfaces;
using FullStackDevExercise.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise.Services
{
    public static class ServiceDependencies
    {
        public static void Initialize(IServiceCollection services)
        {
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IAppointmentservice, AppointmentService>();
        }
    }
}
