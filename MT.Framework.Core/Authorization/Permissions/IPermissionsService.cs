using MT.Framework.Core.Authorization.AuthRequirements;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MT.Framework.Core.Authorization.Permissions
{
    public interface IPermissionsService
    {
        /// <summary>
        /// Checks if the user has the permission to perform the operation on the entity's reference in the context of a tenant
        /// </summary>
        /// <param name="tenantId">The tenant identifier</param>
        /// <param name="userId">The user identifier</param>
        /// <param name="entityId">The entity identifier</param>
        /// <param name="referenceId">The record identifier</param>
        /// <param name="operationType">The type of the operation under consideration</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><c>true</c> if the user has the permissions and <c>false</c> otherwise </returns>
        Task<bool> HasPermissionAsync(Guid tenantId, Guid userId, string entityId, Guid referenceId, OperationType operationType, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the user from a tenant has the permission to perform the operation on the target tenant that may own the record of the entity
        /// </summary>
        /// <param name="userId">The user identifier</param>
        /// <param name="userTenantId">The source tenant identifier</param>
        /// <param name="entityTenantId">The target tenant identifier</param>
        /// <param name="entityId">The entity identifier</param>
        /// <param name="referenceId">The record identifier</param>
        /// <param name="operationType">The type of the operation under consideration</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><c>true</c> if the user has the permissions and <c>false</c> otherwise </returns>
        Task<bool> HasTenantAccessPermissionsAsync(Guid userId, Guid userTenantId, Guid entityTenantId, string entityId, Guid referenceId, OperationType operationType, CancellationToken cancellationToken);
    }
}
