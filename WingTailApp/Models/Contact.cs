using MT.Framework.Core.EntityModels;
using System;

namespace WingTailApp.Models
{
    [Serializable]
    public class Contact : IAuditableTenantEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public Guid TenantId { get; set; }
        public string EntityId => "Contact";
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
