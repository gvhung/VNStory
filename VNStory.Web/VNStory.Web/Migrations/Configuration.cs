using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VNStory.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VNStory.Web.Areas.Membership.Models;
    using VNStory.Web.DataContexts;    

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = $"VNStory.Web.DataContexts.{nameof(ApplicationDbContext)}";
        }

        protected override void Seed(ApplicationDbContext context)
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
                new ApplicationUser {UserName = "gvhung", Email = "gvhung@hotmail.com", PasswordHash = "1234@5678", EmailConfirmed = true }
            };

            // check for exist role
            foreach (var defaultRole in defaultRoles)
            {
                if (context.Roles.Any(r => r.Name == defaultRole))
                {
                    continue;
                }
                var roleStore = new RoleStore<IdentityRole>(context);
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
                if (context.Users.Any(u => u.UserName == user.UserName))
                {
                    continue;
                }
                var userStore = new UserStore<ApplicationUser>(context);
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
