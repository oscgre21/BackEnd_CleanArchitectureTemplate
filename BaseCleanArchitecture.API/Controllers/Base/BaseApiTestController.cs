using BaseCleanArchitecture.BL.DTOs.Base;
using BaseCleanArchitecture.Services.Base;
using BaseCleanArchitecture.Services.Demo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BaseCleanArchitecture.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiTestController<TEntityDto>  : ControllerBase 
         where TEntityDto : class, IBaseEntityDto
    {
        ITestDemoServicesGlobal<TEntityDto> _demo;
        public BaseApiTestController(ITestDemoServicesGlobal<TEntityDto> demo)
        {
            _demo = demo;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> get()
        {
            var model = await _demo.GetListOfN();
            return Ok(model);
        }
        /*
        [HttpGet]
        [Route("getByID")]
        public async Task<IActionResult> getByID(Guid ids)
        {
            var model = await _demo.GetOfByID<TEntityDto>(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> save([FromBody] TEntityDto obj)
        {
            if (ModelState.IsValid)
            {
                var info = await _demo.SaveOf(obj);
                return Ok(info);
            }

            return NotFound();
        }*/
    }
}
