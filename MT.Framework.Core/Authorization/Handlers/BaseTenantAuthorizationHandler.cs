using Microsoft.AspNetCore.Authorization;
using MT.Framework.Core.Authorization.AuthRequirements;
using MT.Framework.Core.Authorization.Permissions;
using MT.Framework.Core.EntityModels;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MT.Framework.Core.Authorization
{
    public abstract class BaseTenantAuthorizationHandler<T> : AuthorizationHandler<MultiTenancyAuthorizationRequirement<T>, T> where T : IAuditableTenantEntity
    {
        public BaseTenantAuthorizationHandler() { }

        protected readonly IPermissionsService _permissionsService;
        protected readonly Func<ClaimsPrincipal, MultiTenancyAuthorizationRequirement<T>, T, Task> _customValidator;

        public BaseTenantAuthorizationHandler(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        public BaseTenantAuthorizationHandler(IPermissionsService permissionsService, Func<ClaimsPrincipal, MultiTenancyAuthorizationRequirement<T>, T, Task> customValidator)
        {
            _permissionsService = permissionsService;
            _customValidator = customValidator;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MultiTenancyAuthorizationRequirement<T> requirement, T resource)
        {
            // if there is a custom validator, fully honour that and do not poke nose into the flow.
            if (null != _customValidator) await _customValidator(context.User, requirement, resource);

            // if the user is not yet authenticated, throw as failed and do not pass on to the other implementations.
            if (null == context.User || null == context.User.Identity || !context.User.Identity.IsAuthenticated) context.Fail();

            Guid tenantId = context.User.Identity.GetValue<Guid>(CustomClaimTypes.TenantIdClaim), userId = context.User.Identity.GetValue<Guid>(ClaimTypes.NameIdentifier);

            // if (Guid.Empty.Equals(requirement.TenantId) && !Guid.Empty.Equals(tenantId)) requirement.TenantId = tenantId;

            var hasPermission = await _permissionsService.HasPermissionAsync(tenantId, userId, requirement.EntityId, requirement.ReferenceId, requirement.OperationType, CancellationToken.None);

            if (!hasPermission) Trace.WriteLine("The user does not have the permission to perform the operation on the entity");

            var hasTenantAccessPermission = await _permissionsService.HasTenantAccessPermissionsAsync(userId, tenantId, requirement.TenantId, requirement.EntityId, requirement.ReferenceId, requirement.OperationType, CancellationToken.None);

            if (!hasTenantAccessPermission) Trace.WriteLine("The user does not have the permission to perform the operation on the entity for the tenant that possesses the entity");

            if (hasPermission && hasTenantAccessPermission) context.Succeed(requirement);
        }
    }
}
