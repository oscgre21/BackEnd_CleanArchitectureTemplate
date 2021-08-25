using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Services.Logging
{
    public class SentryLogger : ILoggingService
    {
        private readonly IHub _sentryHub;
        public SentryLogger(IHub  hub)
        {
            _sentryHub = hub;
        }

        public void Info(string message)
        {
            _sentryHub.CaptureMessage(message);
        }
    }
}
