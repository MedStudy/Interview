using FullStackDevExercise.Services;
using FullStackDevExercise.ViewModels.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackDevExercise
{
  public partial class Startup
  {
    private void RegisterServiceDependencies(IServiceCollection services)
    {
      // Register services
      services.AddScoped<IPetOwnerService, PetOwnerService>();
      services.AddScoped<IAppointmentService, AppointmentService>();

      // Register codecs
      services.AddScoped<IOwnerMapper, OwnerMapper>();
      services.AddScoped<IPetMapper, PetMapper>();
      services.AddScoped<IAppointmentMapper, AppointmentMapper>();
    }
  }
}
