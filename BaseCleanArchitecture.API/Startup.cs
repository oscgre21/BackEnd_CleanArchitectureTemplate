using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using BaseCleanArchitecture.BL.Validations;
using BaseCleanArchitecture.Core.ConfigModels;
using BaseCleanArchitecture.Core.IoC;
using BaseCleanArchitecture.Domain.Contexts;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.IoC;
using BaseCleanArchitecture.Services.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCleanArchitecture.API.Models;
using Sentry.AspNetCore;
using BaseCleanArchitecture.BL.Validations.Global;

namespace BaseCleanArchitecture.API
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
            services.AddControllers()
                //Adding Fluent Validation
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DemoValidator>());

            #region Global Filters
            
            #endregion

            #region CORS
            var securitySettings = Configuration.GetSection("SecurityConfig").Get<SecurityConfig>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins(securitySettings.CORSClientUrls);
                    });
            });
            #endregion

            #region DbContext Config
            var connectionString = Configuration.GetConnectionString("CloudConnection");
            var sqlVersion = ServerVersion.AutoDetect(connectionString);
            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<BaseDBContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, sqlVersion)
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            ,
            ServiceLifetime.Transient);
            #endregion

            #region IoC Registry
            services.AddCoreRegistry();
            services.AddDatamodelRegistry();
            services.AddOnlyEntityServicesRegistry();
            #endregion

            #region Adding Auth 
            var authenticationConfig = Configuration.GetSection("AuthenticationConfig").Get<AuthenticationSettings>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = authenticationConfig.Authority;
                    options.RequireHttpsMetadata = true;
                    //
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization();
            #endregion

            #region Swagger COnfig
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API V1",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });
            #endregion

            #region AutoMapper Config
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            // Enable automatic tracing integration.
            // Make sure to put this middleware right after `UseRouting()`.
           // app.UseSentryTracing();
            //
            app.UseCors("AllowAllPolicy");
            //
            app.UseAuthentication();
            app.UseAuthorization();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Base Clean Architecture");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();
            });
        }
    }
}