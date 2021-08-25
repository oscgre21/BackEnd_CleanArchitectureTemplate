using BaseCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Services.JWTFactory
{
    public interface IJwtFactory
    {
        string GenerateToken(AppUser user);
    }
}
