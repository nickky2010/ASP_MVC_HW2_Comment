using ASP_MVC_HW2_Comment.App_LocalResources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models.ViewModel
{
    public class CommentViewModel
    {
        [Display(Name = "DateTimeCreation", ResourceType = typeof(Resource))]
        public DateTime DateTimeOfCreation { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterTextMessage")]
        [StringLength(300, MinimumLength = 2, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateStringLengthTextMessage")]
        [Display(Name = "CommentTextMessage", ResourceType = typeof(Resource))]
        public string TextMessage { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        public string Firstname { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        public string Lastname { get; set; }
        
    }
}
