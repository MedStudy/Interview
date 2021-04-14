using FSDExercise.Infra.Services.Contracts;
using FSDExercise.Infra.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Configurations
{
    public static class IServiceCollectionExtension
    {
      public static void AddFSDExerciseInfraWrapper(this IServiceCollection services)
      {
        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IPetService, PetService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
      }
    }
}
