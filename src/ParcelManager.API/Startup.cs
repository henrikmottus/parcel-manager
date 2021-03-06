using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ParcelManager.API.Automapper.Profiles;
using ParcelManager.API.Interfaces;
using ParcelManager.API.Middlewares;
using ParcelManager.API.Services;
using ParcelManager.Core.Entities;
using ParcelManager.Core.Interfaces;
using ParcelManager.Core.Validators;
using ParcelManager.Infrastructure.Data.Context;
using ParcelManager.Infrastructure.Data.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ParcelManager.API
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
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped(typeof(IShipmentRepository), typeof(ShipmentRepository));

            services.AddScoped<IShipmentDtoService, ShipmentDtoService>();
            services.AddScoped<IBagDtoService, BagDtoService>();
            services.AddScoped<IParcelDtoService, ParcelDtoService>();

            services.AddDbContext<ParcelContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Parcel"]);                
            });

            services.AddAutoMapper(typeof(BaseProfile));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParcelManager", Version = "v1" });
            });

            services.AddControllersWithViews()
                .AddFluentValidation()
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }
            );

            services.AddTransient<IValidator<Shipment>, ShipmentValidator>();
            services.AddTransient<IValidator<Bag>, BagValidator>();
            services.AddTransient<IValidator<BagWithLetters>, BagWithLettersValidator>();
            services.AddTransient<IValidator<BagWithParcels>, BagWithParcelsValidator>();
            services.AddTransient<IValidator<Parcel>, ParcelValidator>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParcelManager v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ErrorHandler>();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
