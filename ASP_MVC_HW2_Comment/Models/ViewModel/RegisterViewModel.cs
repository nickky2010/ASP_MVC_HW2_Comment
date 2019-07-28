using ASP_MVC_HW2_Comment.App_LocalResources;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_HW2_Comment.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateStringLengthFirstName")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterFirstName")]
        public string Firstname { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateStringLengthLastName")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterLastName")]
        public string Lastname { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resource))]
        [RegularExpression(@"^[A-Za-z]{3}_\d{3}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateLogin")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterLogin")]
        public string Login { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterEmail")]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterPassword")]
        [StringLength(10, MinimumLength = 6, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ValidateStringLengthPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EnterConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordsDoNotMatch")]
        public string ConfirmPassword { get; set; }
    }
}