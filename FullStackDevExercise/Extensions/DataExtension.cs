using FullStackDevExercise.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise.Extensions
{
  public static class DataExtension
  {
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
      services.AddTransient<IOwnerRepository, OwnerRepository>();
      services.AddTransient<IAppointmentRepository, AppointmentRepository>();
      return services;
    }
  }
}
