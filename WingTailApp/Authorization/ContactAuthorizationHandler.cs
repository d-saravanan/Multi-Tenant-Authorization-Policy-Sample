using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WingTailApp.Models;

namespace WingTailApp.Authorization
{
    public class ViewContactAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Contact>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Contact resource)
        {
            if (context.User == null || context.User.Identity == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.FromResult(0);
            }

            var userIdClaim = context.User.FindFirst(ClaimTypes.Sid)?.Value ?? "";

            if (string.IsNullOrWhiteSpace(userIdClaim) || !DefaultPermissions.Defaults.ContainsKey(userIdClaim))
            {
                //Explicitly fail and do not allow the other handlers to execute as this is for a single entity and a common permission checker.
                // If there were Manager, Admin etc, there would be multiple handlers that can fallback if this one fails. Hence this design
                context.Fail();
                return Task.FromResult(0);
            }

            if (!DefaultPermissions.Defaults[userIdClaim].Equals("View_Contact"))
            {
                context.Fail();
                return Task.FromResult(0);
            }

            context.Succeed(requirement);
            return Task.FromResult(0);
        }
    }
}
