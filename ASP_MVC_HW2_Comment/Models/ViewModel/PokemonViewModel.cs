using System.ComponentModel.DataAnnotations;

namespace BLL.Models.ViewModel
{
    public class PokemonViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фото")]
        public string PathPicture { get; set; }
    }
}
