using ASP_MVC_HW2_Comment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO.Account
{
    public class UserProfileDTO
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<CommentDTO> CommentDTOs { get; set; }
        public UserProfileDTO()
        {
            CommentDTOs = new List<CommentDTO>();
        }
    }
}
