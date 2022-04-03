using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VNStory.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VNStory.Web.DataContexts
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}