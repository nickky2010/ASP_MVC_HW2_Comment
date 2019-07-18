using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models.ViewModel
{
    public class CommentViewModel
    {
        [Display(Name = "Date and time of creation", Prompt = "Date and time")]
        public DateTime DateTimeOfCreation { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Введите текст комментария")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Количество символов должно быть в пределах от 2 до 300")]
        [Display(Name = "Text message", Prompt = "Text message")]
        public string TextMessage { get; set; }
        [Display(Name = "First name", Prompt = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "Last name", Prompt = "Last name")]
        public string Lastname { get; set; }
        
    }
}
