using MT.Framework.Core.Authorization.AuthRequirements;

namespace WingTailApp.Models
{
    public class ContactAuthorizationRequirement : MultiTenancyAuthorizationRequirement<Contact>
    {
        public ContactAuthorizationRequirement(Contact entity) : base(entity)
        {
        }
    }
}
