using System;

namespace MT.Framework.Core.EntityModels
{
    public interface IAuditableEntity
    {
        Guid Id { get; set; }
        string EntityId { get; }
        Guid CreatedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        Guid ModifiedBy { get; set; }
        DateTimeOffset ModifiedOn { get; set; }
        bool IsActive { get; set; }
    }
}
