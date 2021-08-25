using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Services.Logging
{
    public interface ILoggingService
    {
        void Info(string message);
    }
}
