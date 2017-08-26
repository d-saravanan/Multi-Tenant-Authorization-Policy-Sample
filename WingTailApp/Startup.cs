using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using WingTailApp.Authorization;
using WingTailApp.Services;
using WingTailApp.Models;
using MT.Framework.Core.Authorization.Permissions;

namespace WingTailApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth");
            services.AddMvc(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder("CookieAuth").RequireAuthenticatedUser().Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddScoped<IAuthorizationRequirement, ContactAuthorizationRequirement>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IAuthorizationService, DefaultAuthorizationService>();
            services.AddScoped<IAuthorizationHandler, MTViewContactAuthorizationHandler>();
            services.AddScoped<IPermissionsService, DummyPermissionsService>();
            services.AddScoped<IContactsService, ContactsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
