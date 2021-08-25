using Microsoft.Extensions.DependencyInjection;
using BaseCleanArchitecture.Domain.Contexts;
using BaseCleanArchitecture.Domain.Repositories;
using BaseCleanArchitecture.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Domain.IoC
{
    public static class DatamodelRegistry
    {
        public static void AddDatamodelRegistry(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork<BaseDBContext>, ContextUnitOfWork>();
            
        }
    }
}
