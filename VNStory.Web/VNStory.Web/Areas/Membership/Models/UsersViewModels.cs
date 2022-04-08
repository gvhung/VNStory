using System.ComponentModel.DataAnnotations;

namespace VNStory.Web.Areas.Membership.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}