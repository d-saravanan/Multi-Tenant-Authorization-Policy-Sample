using System;

namespace WingTailApp.Services
{
    public class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }
    }
}