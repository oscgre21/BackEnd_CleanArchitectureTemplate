using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseCleanArchitecture.API.Controllers.Base;
using BaseCleanArchitecture.BL.DTOs.ViewModel;
using BaseCleanArchitecture.Services.Demo;
using BaseCleanArchitecture.BL.DTOs.Global;

namespace BaseCleanArchitecture.API.Controllers.Global.Generales
{
    [AllowAnonymous]
    public class DemoController : BaseMinApiController
    {

        IDemoServices _demo;

        public DemoController(IDemoServices demo)
        {
            _demo = demo; 
        }
        #region CRUD
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> get()
        {
            var model = await _demo.GetListOf();
            return Ok(model);
        }

        [HttpGet]
        [Route("getByID")]
        public async Task<IActionResult> getByID(Guid ids)
        {
            var model = await _demo.GetOfByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> save([FromBody] DemoDto obj)
        {
            if (ModelState.IsValid)
            {
                var info = await _demo.SaveOf(obj);
                return Ok(info);
            }

            return NotFound();
        }

        #endregion

    }
}
 