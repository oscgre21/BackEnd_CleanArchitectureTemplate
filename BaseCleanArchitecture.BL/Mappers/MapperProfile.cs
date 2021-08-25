using AutoMapper;
using BaseCleanArchitecture.BL.DTOs;
using BaseCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BaseCleanArchitecture.Domain.Entities.Global;
using BaseCleanArchitecture.BL.DTOs.Global; 

namespace BaseCleanArchitecture.BL.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Globales
            CreateMap<Demo, DemoDto>()
                .ReverseMap();
    

            #endregion
                         

        }
    }
}
