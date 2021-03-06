﻿using System;
using Microsoft.Owin;
using Owin;
using MovieDb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


[assembly: OwinStartupAttribute(typeof(MovieDb.Startup))]
namespace MovieDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";

                string userPWD = "$milliomos99";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded) { 
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

            }

            if (!roleManager.RoleExists("DefaultUser"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "DefaultUser";
                roleManager.Create(role);
            }

        }

    }
}
