using BaseCleanArchitecture.Core.Basemodel.BaseEntity;
using BaseCleanArchitecture.Domain.Contexts;
using BaseCleanArchitecture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Domain.UnitOfWork
{
    public class ContextUnitOfWork : IUnitOfWork<BaseDBContext>
    {
        public BaseDBContext Context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public ContextUnitOfWork(IServiceProvider serviceProvider, BaseDBContext context)
        {
            _serviceProvider = serviceProvider;
            this.Context = context;
        }

        public async Task<int> Commit()
        {
            var result = await Context.SaveChangesAsync();
            return result;
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IRepository<TEntity>;
        }
    }
}
