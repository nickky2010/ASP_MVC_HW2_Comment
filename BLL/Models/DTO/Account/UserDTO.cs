using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ASP_MVC_HW2_Comment.Models.Account
{
    public class UserDTO : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public RoleDTO Role { get; set; }
        public ICollection<CommentDTO> CommentDTOs { get; set; }
        public UserDTO()
        {
            CommentDTOs = new List<CommentDTO>();
        }
    }
}