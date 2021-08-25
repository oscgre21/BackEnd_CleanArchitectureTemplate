using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Core.ConfigModels
{
    public class AuthenticationSettings
    {
        public string Authority { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
