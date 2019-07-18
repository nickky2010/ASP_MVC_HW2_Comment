using ASP_MVC_HW2_Comment.Models.Account;
using BLL.Models.DTO.Account;
using System;

namespace ASP_MVC_HW2_Comment.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public string TextMessage { get; set; }
        public UserProfileDTO UserProfileDTO { get; set; }
    }
}