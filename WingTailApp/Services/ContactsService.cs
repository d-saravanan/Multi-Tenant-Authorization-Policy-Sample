using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTailApp.Models;

namespace WingTailApp.Services
{
    public class ContactsService : IContactsService
    {
        private static List<Contact> _ = new List<Contact>
        {
            new Contact
            {
                EmailId = "admin@t1.com",
                Id= Guid.NewGuid(),
                Name = System.IO.Path.GetRandomFileName(),
                TenantId = Guid.Parse("FA7CB737-A95A-480F-B77F-0C867C5D67D5" )
            },
            new Contact
            {
                EmailId = "admin@t2.com",
                Id= Guid.NewGuid(),
                Name = System.IO.Path.GetRandomFileName(),
                TenantId = Guid.Parse("508B26F7-C776-48C3-9023-1469688B1777"  )
            },
            new Contact
            {
                EmailId = "admin@t5.com",
                Id= Guid.NewGuid(),
                Name = System.IO.Path.GetRandomFileName(),
                TenantId = Guid.Parse("D3B37AFE-425C-4E8C-9486-F5A0A097C44F")
            }
        };

        private static Random _rnd = new Random();

        public Contact GetContactById(Guid id)
        {
            return _[_rnd.Next(0, 2)];
        }
    }
}
