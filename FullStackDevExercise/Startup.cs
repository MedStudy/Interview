using FSDExercise.Core.Configurations;
using FSDExercise.DB;
using FSDExercise.DB.Actions;
using FSDExercise.Infra.Configurations;
using FullStackDevExercise.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FullStackDevExercise
{
    public class Startup
    {
        private readonly long maxRequestSizeAllowed = 3200000000;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSingleton<FSDExerciseDBContext>();
            services.AddScoped<IDBOperations, DBOperations>();
            services.AddFSDExerciseCoreWrapper();
            services.AddFSDExerciseInfraWrapper();
            services.AddSwaggerGen(options =>
            {
              options.SwaggerDoc("v1", new OpenApiInfo
              {
                Title = "DoLittle",
                Version = "v1"
              });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoLittle Api");
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllers();
              //endpoints.MapControllerRoute(
              //      name: "default",
              //      pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.Use(async (context, next) =>
            {
              context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = maxRequestSizeAllowed;
              await next.Invoke();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{              
            //  c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoLittle Api");              
            //});

        }
    }
}
