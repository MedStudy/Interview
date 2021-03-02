using FullStackDevExercise.Services.Contracts;
using FullStackDevExercise.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise.Extensions
{
  public static class ServiceExtension
  {
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
      services.AddTransient<IOwnerService, OwnerService>();
      services.AddTransient<IAppointmentService, AppointmentService>();
      return services;
    }
  }
}
