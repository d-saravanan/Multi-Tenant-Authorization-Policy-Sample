using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTailApp.Models;

namespace WingTailApp.Services
{
    public interface IContactsService
    {
        Contact GetContactById(Guid id);
    }
}
