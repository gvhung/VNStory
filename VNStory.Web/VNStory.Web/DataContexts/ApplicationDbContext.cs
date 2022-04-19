using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VNStory.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using VNStory.Web.Areas.Admin.Models;

namespace VNStory.Web.DataContexts
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Author> Authors { get; set; }
        public System.Data.Entity.DbSet<Bookmark> Bookmarks { get; set; }
        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public System.Data.Entity.DbSet<Chapter> Chapters { get; set; }
        public System.Data.Entity.DbSet<Reading> Readings { get; set; }
        public System.Data.Entity.DbSet<Story> Stories { get; set; }        
        
        
    }
}