using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieProject.API.DTOs;
using MovieProject.API.Filters;
using MovieProject.Core.Repositories;
using MovieProject.Core.Services;
using MovieProject.Core.UnitOfWorks;
using MovieProject.Data;
using MovieProject.Data.Repositories;
using MovieProject.Data.UnitOfWorks;
using MovieProject.Service.Services;
using Newtonsoft.Json;

namespace MovieProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   // Projemiz herhangi bir interface ile karþýlaþtýðý zaman, o interfacenin ctor'una git ve o interfacenin servisinden bir örnek oluþtur.

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>(); // Herhangi bir class'ýn içerisinde IUnifOfWork ile karþýlaþýrsa, UnitOfWork nesne üret anlamýna gelen servistir.

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICinemaService, CinemaService>();

            services.AddScoped<NotFoundFilter>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("MovieProject.Data");
                });
            });

            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter()); // Tüm controllerlarým için ValidationFilter kullanýlsýn diyorum
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; // Servise, hatalarý benim kontrol ediceðimi belirtiyorum.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;

                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var ex = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
