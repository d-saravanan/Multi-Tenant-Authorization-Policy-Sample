using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingTailApp.Services;
using Microsoft.AspNetCore.Authorization;
using WingTailApp.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using MT.Framework.Core.Authorization.AuthRequirements;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingTailApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IContactsService _contactsService;

        // Refer: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection
        public ContactsController(IAuthorizationService authorizationService, IContactsService contactsService)
        {
            _authorizationService = authorizationService;
            _contactsService = contactsService;
        }

        // GET: /<controller>/
        public async Task<JsonResult> Get()
        {
            var authStatus = await _authorizationService.AuthorizeAsync(HttpContext.User, new Contact(), new ContactAuthorizationRequirement(new Contact())
            {
                OperationType = OperationType.View
            });

            if (authStatus.Succeeded)
                return Json(_contactsService.GetContactById(Guid.Empty));

            return Json("UnAuthorized");
        }
    }
}
