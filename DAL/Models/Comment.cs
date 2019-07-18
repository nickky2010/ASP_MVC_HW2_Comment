using ASP_MVC_HW2_Comment.DAL.Models.Account;
using System;

namespace ASP_MVC_HW2_Comment.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public string TextMessage { get; set; }
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}