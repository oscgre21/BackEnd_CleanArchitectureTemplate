using Microsoft.Extensions.DependencyInjection;  
using BaseCleanArchitecture.Services.JWTFactory; 
using System;
using System.Collections.Generic;
using System.Text;
using BaseCleanArchitecture.Services.Global;
using BaseCleanArchitecture.Services.Base;
using BaseCleanArchitecture.Services.Logging;
using BaseCleanArchitecture.Services.Demo;

namespace BaseCleanArchitecture.Services.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddOnlyEntityServicesRegistry();
            services.AddScoped<IJwtFactory, JwtFactory>();  
    
        }

        public static void AddOnlyEntityServicesRegistry(this IServiceCollection services)
        { 
     
             

            services.AddScoped(typeof(IBaseEntityService<,>) , typeof(BaseEntityService<,>));
            
            services.AddScoped<IDemoServices, DemoServices>();

            services.AddScoped<ITestDemoServices, TestDemoServices>();

            // services.AddScoped<ILoggingService, SentryLogger>(); 
        }
    }
}
