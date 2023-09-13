using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;




namespace PeliculaCFHN.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {

                  services.AddCors();// agregar los cors

                  services.AddControllers();
                  services.AddSwaggerGen(c =>
                  {

                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeliculaCFHN.WebAPI", Version = "v1" });


                            var jwtSecurityScheme = new OpenApiSecurityScheme
                            {
                                   Scheme = "bearer",
                                   BearerFormat = "JWT",
                                   Name = "JWT Authentication",
                                   In = ParameterLocation.Header,
                                   Type = SecuritySchemeType.Http,
                                   Description = "Ingresar tu token de JWT Authentication",



                                Reference = new OpenApiReference
                                {
                                      Id = JwtBearerDefaults.AuthenticationScheme,
                                      Type = ReferenceType.SecurityScheme
                                }

                            };

                             c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                             c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });

              





           });

        }


       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeliculaCFHN.WebAPI v1"));
            }
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

            }
        }

    }
}
