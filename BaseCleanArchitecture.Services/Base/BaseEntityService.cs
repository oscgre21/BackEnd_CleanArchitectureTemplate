using AutoMapper;
using BaseCleanArchitecture.BL.DTOs.Base;
using BaseCleanArchitecture.Core.Basemodel.BaseEntity;
using BaseCleanArchitecture.Domain.Contexts;
using BaseCleanArchitecture.Domain.Repositories;
using BaseCleanArchitecture.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Services.Base
{
    public class BaseEntityService<TEntity, TEntityDto> : IBaseEntityService<TEntity, TEntityDto>
        where TEntity : class, IBaseEntity
         where TEntityDto : class, IBaseEntityDto
    {
        protected readonly IUnitOfWork<BaseDBContext> _uow;
        protected readonly IMapper _mapper;
        public BaseEntityService(IUnitOfWork<BaseDBContext> uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TEntityDto> Create(TEntityDto entityDto)
        {
            TEntity entity = _mapper.Map<TEntity>(entityDto);

            _uow.GetRepository<TEntity>().Add(entity);
            await _uow.Commit();

            entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        public async Task<TEntityDto> Delete(Guid id)
        {
            TEntity entity = await GetById(id);

            if (entity is null)
                return null;

            _uow.GetRepository<TEntity>().Delete(entity);
            await _uow.Commit();

            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null,
                int? page = null,
                int? pageSize = null,
                SortExpression<TEntity> sortExpressions = null)
        {
            return _uow.GetRepository<TEntity>().Get(predicate,
                page,
                pageSize,
                sortExpressions);
        }

        public Task<TEntity> GetById(Guid id)
        {
            return _uow.GetRepository<TEntity>().GetById(id);
        }

        public TEntityDto Map(TEntity entity)
        {
            return _mapper.Map<TEntityDto>(entity);
        }

        public IEnumerable<TEntityDto> Map(IEnumerable<TEntity> entity)
        {
            return _mapper.Map<IEnumerable<TEntityDto>>(entity);
        }

        public async Task<TEntityDto> Update(Guid id, TEntityDto entityDto)
        {
            TEntity entity = await GetById(id);
            if (entity is null)
                return null;

            _mapper.Map(entityDto, entity);

            _uow.GetRepository<TEntity>().Update(entity);

            await _uow.Commit();

            return _mapper.Map(entity, entityDto);
        }

        public async Task<IEnumerable<TEntityDto>> GetWithMap
            (Expression<Func<TEntity, bool>> predicate = null,
               int? page = null,
               int? pageSize = null,
               SortExpression<TEntity> sortExpressions = null)
        {
            var list =await _uow.GetRepository<TEntity>().Get(predicate,
                page,
                pageSize,
                sortExpressions);
            return Map(list);
        }

        public async Task<bool> CreateWithMap(TEntityDto model)
        { 
            var suscripcion = _mapper.Map<TEntity>(model); 
            _uow.GetRepository<TEntity>().Add(suscripcion);
            var data = await _uow.Commit();
            return data >= 1 ? true : false; 
        }

        public Task<IEnumerable<TEntityDto>> GetListOf()
        {
            return GetWithMap();
        }

        public async Task<TEntityDto> GetOfByID(Guid id)
        {
            var data = (await GetWithMap(x => x.Id.Equals(id))).SingleOrDefault();
            return data;
        }

        public async Task<bool> SaveOf(TEntityDto obj)
        {
            return await CreateWithMap(obj);
        }
    }
}
