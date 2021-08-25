using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Core.Basemodel.Base
{
    public interface IBase
    {
        Guid Id { get; set; }
        bool Deleted { get; set; }
    }
}
