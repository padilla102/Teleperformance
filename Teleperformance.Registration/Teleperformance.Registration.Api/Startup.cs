using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

using Teleperformance.Registration.Infrastruture.Data;
using Teleperformance.Registration.Domain;
using Teleperformance.Registration.Infrastruture;
using Teleperformance.Registration.Api.Extensions;
using System.IO;
using NLog;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace Teleperformance.Registration.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var nLogConfigPath = string.Concat(Directory.GetCurrentDirectory(), "/nlog.config");
            if (File.Exists(nLogConfigPath)) { LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Agregar EF
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Teleperformance.Registration.Infrastruture")));

            services.AddControllers();

            
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Latest).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddOptions();

            services.AddAutoMapper(typeof(Startup));

            // Register the Swagger generator, defining 1 or more Swagger documents
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreApiStarter", Version = "v1" });
            });

            // Registrar nuestro servicios con Autofac container.
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new InfrastructureModule());

            // Presenters
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();

            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
            );

            if (app != null)
                Seed.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseExceptionHandler(
               builder =>
               {
                   builder.Run(
                       async context =>
                       {
                           context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                           context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                           var error = context.Features.Get<IExceptionHandlerFeature>();
                           if (error != null)
                           {
                               context.Response.AddApplicationError(error.Error.Message);
                               await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                           }
                       });
               });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeleperformaceRegister V1");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
