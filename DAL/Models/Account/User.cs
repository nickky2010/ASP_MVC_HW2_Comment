using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_MVC_HW2_Comment.DAL.Models.Account
{
    public class User : IdentityUser
    {
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}