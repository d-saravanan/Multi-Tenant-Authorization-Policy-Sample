using MT.Framework.Core.Authorization.AuthRequirements;
using MT.Framework.Core.Authorization.Permissions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WingTailApp.Services
{
    public class DummyPermissionsService : IPermissionsService
    {
        public async Task<bool> HasPermissionAsync(Guid tenantId, Guid userId, string entityId, Guid referenceId, OperationType operationType, CancellationToken cancellationToken)
        {
            return true;
        }

        public async Task<bool> HasTenantAccessPermissionsAsync(Guid userId, Guid userTenantId, Guid entityTenantId, string entityId, Guid referenceId, OperationType operationType, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
