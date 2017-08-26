using Microsoft.AspNetCore.Authorization;
using MT.Framework.Core.EntityModels;
using System;

namespace MT.Framework.Core.Authorization.AuthRequirements
{
    public abstract class MultiTenancyAuthorizationRequirement<T> : IAuthorizationRequirement where T : IAuditableTenantEntity
    {
        protected readonly T _entity;
        protected MultiTenancyAuthorizationRequirement(T entity)
        {
            _entity = entity;
        }

        public virtual Guid TenantId => _entity.TenantId;
        public virtual string EntityId => _entity.EntityId;
        public virtual Guid ReferenceId => _entity.Id;

        public virtual OperationType OperationType { get; set; }
        public virtual string Permission => $"{EntityId}_{OperationType}";
    }
}
