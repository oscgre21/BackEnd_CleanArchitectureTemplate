using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BaseCleanArchitecture.Core.Basemodel.BaseEntity;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.Domain.Contexts
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options) { }

        private void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (entry.Entity.Id != null)
                        {
                         //   entry.State = EntityState.Modified;
                          //  goto case EntityState.Modified;
                        }

                        entry.Entity.Deleted = false;
                        if (!entry.Entity.CreatedAt.HasValue)
                            entry.Entity.CreatedAt = DateTimeOffset.Now;
                        entry.Entity.UpdatedAt = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property(x => x.CreatedAt).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.UpdatedAt = DateTimeOffset.Now;

                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        goto case EntityState.Modified;
                }
            }
        }
        private async Task<int> BeforeSaveAsync(Func<Task<int>> action)
        {
            SetAuditEntities();
            return await action.Invoke();
        }
        private int BeforeSave(Func<int> action)
        {
            SetAuditEntities();
            return action.Invoke();
        }
        public override int SaveChanges()
        {
            return BeforeSave(() => base.SaveChanges());
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return BeforeSave(() => base.SaveChanges(acceptAllChangesOnSuccess));
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await BeforeSaveAsync(() => base.SaveChangesAsync(cancellationToken));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }
    }
}
