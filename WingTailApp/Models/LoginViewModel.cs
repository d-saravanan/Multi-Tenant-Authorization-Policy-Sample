using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingTailApp.Models
{
    [Serializable]
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TenantName { get; set; }
        public bool IsPersistent { get; set; }
    }
}
