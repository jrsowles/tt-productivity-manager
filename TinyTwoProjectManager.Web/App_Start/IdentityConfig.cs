﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ProjectManagerDbContext());
            app.CreatePerOwinContext<ApplicationUserService>(ApplicationUserService.Create);
            app.CreatePerOwinContext<ApplicationSignInService>(ApplicationSignInService.Create);
            app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
                new RoleManager<ApplicationRole>(
                    new RoleStore<ApplicationRole>(context.Get<ProjectManagerDbContext>())
                )
            );

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}