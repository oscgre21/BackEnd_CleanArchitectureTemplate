using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseCleanArchitecture.Core.ConfigModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Core.IoC
{
    public static class CoreRegistry
    {
        public static void AddCoreRegistry(this IServiceCollection services)
        {
            services.AddSingleton((serviceProvider) =>
            {
                return getSettings<AuthenticationSettings>(serviceProvider, "AuthenticationConfig");
            });
     
            
        }

        private static T getSettings<T>(IServiceProvider serviceProvider, string sectionName)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var settings = configuration.GetSection(sectionName).Get<T>();
            return settings;

        }

    }
}
