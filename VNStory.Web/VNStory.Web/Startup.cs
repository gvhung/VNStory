using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(VNStory.Web.Startup))]
namespace VNStory.Web
{
    public partial class Startup
    {

    //    ApplicationDbContext dbContext = new ApplicationDbContext();

    //    public void Configuration(IAppBuilder app)
    //    {
    //        ConfigureAuth(app);
    //        CreateDefaultRolesAndUser();
    //    }

    //    public void CreateDefaultRolesAndUser()
    //    {
    //        //  This method will be called after migrating to the latest version.

    //        // default user and role
    //        var defaultRoles = new[] { "Administrators", "Users" };
    //        var defaultAdminRole = defaultRoles[0];
    //        var defaultUserRole = defaultRoles[1];

    //        /**
			 //* For this purpose only:
			 //* PasswordHash = real password
			 //* PhoneNumber = Role(s)
			 //*/
    //        var defaultUsers = new[] {
    //            new ApplicationUser {UserName = "admin", Email = "admin@domain.com", PasswordHash = "admin@123"}
    //        };

    //        // check for exist role
    //        foreach (var defaultRole in defaultRoles)
    //        {
    //            if (dbContext.Roles.Any(r => r.Name == defaultRole))
    //            {
    //                continue;
    //            }
    //            var roleStore = new RoleStore<IdentityRole>(dbContext);
    //            var roleManager = new RoleManager<IdentityRole>(roleStore);
    //            var newRole = new IdentityRole { Name = defaultRole };

    //            // add role
    //            var result = roleManager.Create(newRole);
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(result.Errors.First());
    //            }
    //        }

    //        // check for existing user
    //        foreach (var user in defaultUsers)
    //        {
    //            if (dbContext.Users.Any(u => u.UserName == user.UserName))
    //            {
    //                continue;
    //            }
    //            var userStore = new UserStore<ApplicationUser>(dbContext);
    //            var userManager = new UserManager<ApplicationUser>(userStore);
    //            var newUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };

    //            // add user
    //            var resultUser = userManager.Create(newUser, user.PasswordHash);
    //            if (!resultUser.Succeeded)
    //            {
    //                throw new Exception(resultUser.Errors.First());
    //            }

    //            // add role to the user
    //            var resultUserRole = userManager.AddToRole(newUser.Id, defaultAdminRole);
    //            if (!resultUserRole.Succeeded)
    //            {
    //                throw new Exception(resultUserRole.Errors.First());
    //            }

    //            //// lets just add another role to the user
    //            //resultUserRole = userManager.AddToRole(newUser.Id, defaultUserRole);
    //            //if (!resultUserRole.Succeeded)
    //            //{
    //            //    throw new Exception(resultUserRole.Errors.First());
    //            //}
    //        }

    //        //string defaultRoleName = "Administrators";
    //        ////Default Role
    //        //var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
    //        //var userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
    //        //IdentityRole role = new IdentityRole();
    //        //if (!roleManger.RoleExists(defaultRoleName))
    //        //{
    //        //    role.Name = defaultRoleName;
    //        //    roleManger.Create(role);
    //        //    ApplicationUser user = new ApplicationUser();
    //        //    user.UserName = "gvhung";
    //        //    user.Email = "gvhung@hotmail.com";
    //        //    var Check = userManger.Create(user, "W#lcome!");
    //        //    if (Check.Succeeded)
    //        //    {
    //        //        userManger.AddToRole(user.Id, defaultRoleName);
    //        //    }
    //        //}
    //    }

    }
}
