using MT.Framework.Core.Authorization;
using MT.Framework.Core.Authorization.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTailApp.Models;

namespace WingTailApp.Authorization
{
    public class MTViewContactAuthorizationHandler : BaseTenantAuthorizationHandler<Contact>
    {
        public MTViewContactAuthorizationHandler(IPermissionsService permissionsService) : base(permissionsService)
        {
        }
    }
}
