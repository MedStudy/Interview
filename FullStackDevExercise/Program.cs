using System;
using Autofac;
using Dependous;
using FullStackDevExercise.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FullStackDevExercise
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Bootstrapper.BootstrapSchema();
      CreateHostBuilder(args)
        .UseAutoFacContainer(AssemblyPaths.From("FullStackDevExercise.dll"), containerBuilder: builder =>
        {
          builder.RegisterType<Mediator>()
     .As<IMediator>()
     .InstancePerLifetimeScope();

          // request & notification handlers
          builder.Register<ServiceFactory>(context =>
          {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
          });
        }, logger: (e) => Console.WriteLine($"{e}"))
        .Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
