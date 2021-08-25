using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BaseCleanArchitecture.BL.DTOs.Base;
using BaseCleanArchitecture.Core.Basemodel.BaseEntity;
using BaseCleanArchitecture.Domain.Contexts;
using BaseCleanArchitecture.Domain.Repositories;
using BaseCleanArchitecture.Domain.UnitOfWork;
using BaseCleanArchitecture.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using BaseCleanArchitecture.API.Extensions;
namespace BaseCleanArchitecture.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiFactoryController
    {
        public BaseApiFactoryController()
        {
        }
    }
}
