using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BaseCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BaseCleanArchitecture.Domain.Entities.Global; 

namespace BaseCleanArchitecture.Domain.Contexts
{
    public class BaseDBContext : BaseContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            : base(options)
        {
        }

        public DbSet<Demo> Ciudades { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*
            builder.Entity<Demo>()
                .HasIndex(x => x.Codigo)
                .IsUnique();*/
        }
    }
}
