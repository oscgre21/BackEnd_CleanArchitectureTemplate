using BaseCleanArchitecture.BL.DTOs.Base;
using BaseCleanArchitecture.Core.Basemodel.BaseEntity;
using BaseCleanArchitecture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Services.Base
{
    public interface IBaseEntityService<TEntity, TEntityDto>
        where TEntity : class, IBaseEntity
         where TEntityDto : class, IBaseEntityDto
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null,
                int? page = null,
                int? pageSize = null,
                SortExpression<TEntity> sortExpressions = null);

        Task<IEnumerable<TEntityDto>> GetWithMap(Expression<Func<TEntity, bool>> predicate = null,
               int? page = null,
               int? pageSize = null,
               SortExpression<TEntity> sortExpressions = null);

        Task<TEntity> GetById(Guid id);

        Task<TEntityDto> Create(TEntityDto entityDto);

        Task<bool> CreateWithMap(TEntityDto model);

        Task<TEntityDto> Update(Guid id, TEntityDto entityDto);
        Task<TEntityDto> Delete(Guid id);

        TEntityDto Map(TEntity entity);
        IEnumerable<TEntityDto> Map(IEnumerable<TEntity> entity);

        Task<IEnumerable<TEntityDto>> GetListOf();
        Task<TEntityDto> GetOfByID(Guid id);
        Task<bool> SaveOf(TEntityDto obj);
    }

     
}
