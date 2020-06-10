using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SystemPro.Core.Interfaces;
using SystemPro.Core.Services;
using SystemPro.Infrastructure.Data;
using SystemPro.Infrastructure.Filters;
using SystemPro.Infrastructure.Repositories;

namespace SystemPro.Api
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
            //configuracion para integrar servicios con angular
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //SuppressModelStateInvalidFilter nos ayuda a eliminar mensaje de response con data que no le interesa al  request
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
                ;

            //aca resolvemos nuestras dependencias, 
            //cada vez que en el programa se haga uso de esta abtraccion, le entregamos una..
            //instacia del clase (PostRepository)
            //aca podemos cambiar el repository por ende cualquier base de datos
            services.AddTransient<IUserRepository, UserRepository>();


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITypeIdentificationRepository, TypeIdentificationRepository>();
            services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();

            //implementar llamado a la cadena de conexion que esta en appsettings.json
            services.AddDbContext<SystemPro2Context>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("SystemPro2")));


            //de esta manera registramos un filtro de  validacion de forma global
            //registro validator, registrando las validaciones desde las Assemblies
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //generar documentacion API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //configuracion para integrar angular
            app.UseCors("CorsPolicy");
            //app.UsePreflightRequestHandler();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
