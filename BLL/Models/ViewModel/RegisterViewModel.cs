using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_HW2_Comment.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Количество символов должно быть в пределах от 2 до 30")]
        [Required(ErrorMessage = "Введите имя")]
        public string Firstname { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Количество символов должно быть в пределах от 2 до 30")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Lastname { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Количество символов должно быть в пределах от 2 до 30")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Количество символов должно быть в пределах от 6 до 10")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Повторите ввод пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}