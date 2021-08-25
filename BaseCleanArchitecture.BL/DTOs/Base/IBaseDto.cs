using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.DTOs.Base
{
    public interface IBaseDto
    {
        Guid? Id { get; set; }
    }
}
