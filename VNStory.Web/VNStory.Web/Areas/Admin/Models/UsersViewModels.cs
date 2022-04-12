using System.ComponentModel.DataAnnotations;

namespace VNStory.Web.Areas.Admin.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}