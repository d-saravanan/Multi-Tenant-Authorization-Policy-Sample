using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingTailApp.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private static Dictionary<string, List<UserAccount>> _tenantUsers = new Dictionary<string, List<UserAccount>>
        {
            {
                "FA7CB737-A95A-480F-B77F-0C867C5D67D5",
                new List<UserAccount>
                {
                    new UserAccount
                    {
                        Password="admin",
                        TenantId = Guid.Parse("FA7CB737-A95A-480F-B77F-0C867C5D67D5"),
                        UserId = Guid.Parse("FA7CB737-A95A-480F-B55F-0C867C5D67D5" ),
                        UserName="admint1"
                    }
                }
            },
            {
                "508B26F7-C776-48C3-9023-1469688B1777",
                new List<UserAccount>
                {
                    new UserAccount
                    {
                        Password="admin",
                        TenantId = Guid.Parse("508B26F7-C776-48C3-9023-1469688B1777"),
                        UserId = Guid.Parse("508B26F7-C776-48C3-9023-1469688B1675" ),
                        UserName="admint2"
                    }
                }
            },
            {
                "D3B37AFE-425C-4E8C-9486-F5A0A097C44F",
                new List<UserAccount>
                {
                    new UserAccount
                    {
                        Password="admin",
                        TenantId = Guid.Parse("D3B37AFE-425C-4E8C-9486-F5A0A097C44F"),
                        UserId = Guid.Parse("D3B37AFE-425C-4E8C-9486-F5A0A097C23F" ),
                        UserName="admint5"
                    }
                }
            }
        };

        private static Dictionary<string, string> _tenants = new Dictionary<string, string>
        {
            {"tenant1","FA7CB737-A95A-480F-B77F-0C867C5D67D5" },
            {"tenant2","508B26F7-C776-48C3-9023-1469688B1777" },
            {"tenant3","51E29D39-094A-4503-AC6F-54F768CCB70F" },
            {"tenant4","C6AAC0C3-F84D-4914-B611-174C45F15A52" },
            {"tenant5","D3B37AFE-425C-4E8C-9486-F5A0A097C44F" }
        };

        private static string GetTenantIdFromName(string tenantName)
        {
            if (!_tenants.ContainsKey(tenantName)) return string.Empty;
            return _tenants[tenantName];
        }

        public UserAccount IsValidUser(string tenantName, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(tenantName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) return null;
            var tenantId = GetTenantIdFromName(tenantName);
            if (string.IsNullOrWhiteSpace(tenantId)) return null;

            if (!_tenantUsers.ContainsKey(tenantId)) return null;

            return _tenantUsers[tenantId].FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
        }
    }
}
