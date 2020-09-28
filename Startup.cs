using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManageCourses_ms.Domain.Repositories;
using ManageCourses_ms.Domain.Services;
using ManageCourses_ms.Persistence.Repositories;
using ManageCourses_ms.Services;

using ManageCourses_ms.Domain.Models;
using Microsoft.Extensions.Options;
using System;

namespace ManageCourses_ms
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<ICursosRepository, CursosRepository>();
            services.AddScoped<ICursosService, CursosService>();
            services.AddScoped<IEstudiantesRepository, EstudiantesRepository>();
            services.AddScoped<IEstudiantesService, EstudiantesService>();

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
