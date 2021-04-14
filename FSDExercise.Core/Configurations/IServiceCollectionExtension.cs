using FSDExercise.Core.Contracts;
using FSDExercise.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FSDExercise.Core.Configurations
{
  public static class IServiceCollectionExtension
  {
    public static void AddFSDExerciseCoreWrapper(this IServiceCollection services)
    {
      services.AddScoped<IOwnerRepository, OwnerRepository>();
      services.AddScoped<IPetRepository, PetRepository>();
      services.AddScoped<IAppointmentRepository, AppointmentRepository>();
    }
  }
}
