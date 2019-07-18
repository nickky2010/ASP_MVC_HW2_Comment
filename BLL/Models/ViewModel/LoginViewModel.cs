using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_HW2_Comment.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Количество символов должно быть в пределах от 2 до 30")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Количество символов должно быть в пределах от 6 до 10")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}