using ASP_MVC_HW2_Comment.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_HW2_Comment.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Login", ResourceType = typeof(Resource))]
        [RegularExpression(@"^[A-Za-z]{3}_\d{3}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateLogin")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterLogin")]
        public string Login { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterPassword")]
        [StringLength(10, MinimumLength = 6, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateStringLengthPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}