using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
