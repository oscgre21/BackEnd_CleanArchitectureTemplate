using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Core.Basemodel.Base
{
    public class Base : IBase
    {
        public virtual Guid Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
