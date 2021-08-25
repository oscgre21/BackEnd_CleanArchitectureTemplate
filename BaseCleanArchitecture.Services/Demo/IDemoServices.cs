using System;
using BaseCleanArchitecture.BL.DTOs.Global;
using BaseCleanArchitecture.Services.Base;
using BaseCleanArchitecture.Domain.Entities.Global;
using BaseCleanArchitecture.Domain.UnitOfWork;
using BaseCleanArchitecture.Domain.Contexts;
using AutoMapper;

namespace BaseCleanArchitecture.Services.Demo
{

    public interface IDemoServices : IBaseEntityService<BaseCleanArchitecture.Domain.Entities.Global.Demo, DemoDto>
    {

    }
    public class DemoServices : BaseEntityService<BaseCleanArchitecture.Domain.Entities.Global.Demo, DemoDto>, IDemoServices
    {
        public DemoServices(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {

        }
    }
}
