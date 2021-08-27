using System;
using BaseCleanArchitecture.BL.DTOs.Global;
using BaseCleanArchitecture.Services.Base;
using BaseCleanArchitecture.Domain.Entities.Global;
using BaseCleanArchitecture.Domain.UnitOfWork;
using BaseCleanArchitecture.Domain.Contexts;
using AutoMapper;
using BaseCleanArchitecture.BL.DTOs.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Services.Demo
{ 
    public interface ITestDemoServicesGlobal<TEntityDto>
        where TEntityDto : class, IBaseEntityDto
    {
        Task<IEnumerable<TEntityDto>> GetListOfN();

    }
    public abstract class AServicesGlobal<TEntityDto>
     where TEntityDto : class, IBaseEntityDto
    {
        protected abstract Task<IEnumerable<TEntityDto>> GetListOfN();
    }

    public interface ITestDemoServices : IBaseEntityServicesTest<BaseCleanArchitecture.Domain.Entities.Global.Demo>
    {

    }
    public class TestDemoServices : BaseEntityServicesTestImpl<BaseCleanArchitecture.Domain.Entities.Global.Demo>, ITestDemoServices, ITestDemoServicesGlobal<DemoDto>
    {
        public TestDemoServices(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {

        }
        public Task<IEnumerable<DemoDto>> GetListOfN()
        {
            return GetWithMap<DemoDto>();
        }
    } 
}
