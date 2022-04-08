using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;
using VNStory.Web.Areas.Membership.Models;
using VNStory.Web.DataContexts;

[assembly: OwinStartupAttribute(typeof(VNStory.Web.Startup))]
namespace VNStory.Web
{
    public partial class Startup
    {

        //https://www.webtruyenonline.net/

        ApplicationDbContext dbContext = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUser();
        }

        public void CreateDefaultRolesAndUser()
        {
            //  This method will be called after migrating to the latest version.

            // default user and role
            var defaultRoles = new[] { "Administrators", "Users" };
            var defaultAdminRole = defaultRoles[0];
            var defaultUserRole = defaultRoles[1];

            /**
			 * For this purpose only:
			 * PasswordHash = real password
			 * PhoneNumber = Role(s)
			 */
            var defaultUsers = new[] {
                new ApplicationUser {UserName = "gvhung", Email = "gvhung@hotmail.com", PasswordHash = "1234@5678", EmailConfirmed = true}
            };

            // check for exist role
            foreach (var defaultRole in defaultRoles)
            {
                if (dbContext.Roles.Any(r => r.Name == defaultRole))
                {
                    continue;
                }
                var roleStore = new RoleStore<IdentityRole>(dbContext);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var newRole = new IdentityRole { Name = defaultRole };

                // add role
                var result = roleManager.Create(newRole);
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First());
                }
            }

            // check for existing user
            foreach (var user in defaultUsers)
            {
                if (dbContext.Users.Any(u => u.UserName == user.UserName))
                {
                    continue;
                }

                var userStore = new UserStore<ApplicationUser>(dbContext);
                var userManager = new UserManager<ApplicationUser>(userStore);

                // add user
                var resultUser = userManager.Create(user, user.PasswordHash);
                if (!resultUser.Succeeded)
                {
                    throw new Exception(resultUser.Errors.First());
                }

                // add role to the user
                var resultUserRole = userManager.AddToRole(user.Id, defaultAdminRole);
                if (!resultUserRole.Succeeded)
                {
                    throw new Exception(resultUserRole.Errors.First());
                }

            }

        }

    }
}
