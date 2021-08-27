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
    public class BaseEntityServicesTestImpl<TEntity> : IBaseEntityServicesTest<TEntity>
    where TEntity : class, IBaseEntity
    
    {
        protected readonly IUnitOfWork<BaseDBContext> _uow;
        protected readonly IMapper _mapper;
        public BaseEntityServicesTestImpl(IUnitOfWork<BaseDBContext> uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TEntityDto> Create<TEntityDto>(TEntityDto entityDto) where TEntityDto : class, IBaseEntityDto
        {
            TEntity entity = _mapper.Map<TEntity>(entityDto);

            _uow.GetRepository<TEntity>().Add(entity);
            await _uow.Commit();

            entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        public async Task<TEntityDto> Delete<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto
        {
            TEntity entity = await GetById<TEntityDto>(id);

            if (entity is null)
                return null;

            _uow.GetRepository<TEntity>().Delete(entity);
            await _uow.Commit();

            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        public Task<IEnumerable<TEntity>> Get<TEntityDto>(Expression<Func<TEntity, bool>> predicate = null,
                int? page = null,
                int? pageSize = null,
                SortExpression<TEntity> sortExpressions = null) where TEntityDto : class, IBaseEntityDto
        {
            return _uow.GetRepository<TEntity>().Get(predicate,
                page,
                pageSize,
                sortExpressions);
        }

        public Task<TEntity> GetById<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto
        {
            return _uow.GetRepository<TEntity>().GetById(id);
        }

        public TEntityDto Map<TEntityDto>(TEntity entity) where TEntityDto : class, IBaseEntityDto
        {
            return _mapper.Map<TEntityDto>(entity);
        }

        public IEnumerable<TEntityDto> Map<TEntityDto>(IEnumerable<TEntity> entity) where TEntityDto : class, IBaseEntityDto
        {
            return _mapper.Map<IEnumerable<TEntityDto>>(entity);
        }

        public async Task<TEntityDto> Update<TEntityDto>(Guid id, TEntityDto entityDto) where TEntityDto : class, IBaseEntityDto
        {
            TEntity entity = await GetById<TEntityDto>(id);
            if (entity is null)
                return null;

            _mapper.Map(entityDto, entity);

            _uow.GetRepository<TEntity>().Update(entity);

            await _uow.Commit();

            return _mapper.Map(entity, entityDto);
        }

        public async Task<IEnumerable<TEntityDto>> GetWithMap<TEntityDto>
            (Expression<Func<TEntity, bool>> predicate = null,
               int? page = null,
               int? pageSize = null,
               SortExpression<TEntity> sortExpressions = null) where TEntityDto : class, IBaseEntityDto
        {
            var list = await _uow.GetRepository<TEntity>().Get(predicate,
                page,
                pageSize,
                sortExpressions);
            return Map<TEntityDto>(list);
        }

        public async Task<bool> CreateWithMap<TEntityDto>(TEntityDto model) where TEntityDto : class, IBaseEntityDto
        {
            var suscripcion = _mapper.Map<TEntity>(model);
            _uow.GetRepository<TEntity>().Add(suscripcion);
            var data = await _uow.Commit();
            return data >= 1 ? true : false;
        }

        public Task<IEnumerable<TEntityDto>> GetListOf<TEntityDto>() where TEntityDto : class, IBaseEntityDto
        {
            return GetWithMap<TEntityDto>();
        }

        public async Task<TEntityDto> GetOfByID<TEntityDto>(Guid id) where TEntityDto : class, IBaseEntityDto
        {
            var data = (await GetWithMap<TEntityDto>(x => x.Id.Equals(id))).SingleOrDefault();
            return data;
        }

        public async Task<bool> SaveOf<TEntityDto>(TEntityDto obj) where TEntityDto : class, IBaseEntityDto
        {
            return await CreateWithMap(obj);
        }
    }
}
