using System;

namespace MT.Framework.Core.EntityModels
{
    public interface ITenantEntity
    {
        Guid TenantId { get; set; }
    }

    public interface IAuditableTenantEntity : ITenantEntity, IAuditableEntity
    {

    }
}
