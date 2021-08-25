using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.DTOs.Base
{
    public interface IBaseEntityDto : IBaseDto
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        string UpdatedAt { get; set; }
    }
}
