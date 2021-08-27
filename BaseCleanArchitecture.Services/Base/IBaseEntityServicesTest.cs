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
   
    public interface IBaseEntityServicesTest<TEntity>
        where TEntity : class, IBaseEntity
        
    {
        Task<IEnumerable<TEntity>> Get<TEntityDto>(Expression<Func<TEntity, bool>> predicate = null,
                int? page = null,
                int? pageSize = null,
                SortExpression<TEntity> sortExpressions = null) where TEntityDto : class, IBaseEntityDto;

        Task<IEnumerable<TEntityDto>> GetWithMap<TEntityDto>(Expression<Func<TEntity, bool>> predicate = null,
               int? page = null,
               int? pageSize = null,
               SortExpression<TEntity> sortExpressions = null)  where TEntityDto : class, IBaseEntityDto;

        Task<TEntity> GetById<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto;

        Task<TEntityDto> Create<TEntityDto>(TEntityDto entityDto) where TEntityDto : class, IBaseEntityDto;

        Task<bool> CreateWithMap<TEntityDto>(TEntityDto model) where TEntityDto : class, IBaseEntityDto;

        Task<TEntityDto> Update<TEntityDto>(Guid id, TEntityDto entityDto) where TEntityDto : class, IBaseEntityDto;
        Task<TEntityDto> Delete<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto;

        TEntityDto Map<TEntityDto>(TEntity entity) where TEntityDto : class, IBaseEntityDto;
        IEnumerable<TEntityDto> Map<TEntityDto>(IEnumerable<TEntity> entity) where TEntityDto : class, IBaseEntityDto;

        Task<IEnumerable<TEntityDto>> GetListOf<TEntityDto>() where TEntityDto : class, IBaseEntityDto;
        Task<TEntityDto> GetOfByID<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto;
        Task<bool> SaveOf<TEntityDto>(TEntityDto obj) where TEntityDto : class, IBaseEntityDto;


    }
}
