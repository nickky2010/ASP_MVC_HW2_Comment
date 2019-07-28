using ASP_MVC_HW2_Comment.Models.Account;
using ASP_MVC_HW2_Comment.Models.ViewModel;
using AutoMapper;

namespace BLL.Infrastructure.Mapping.Profiles.DTOtoViewModel
{
    public class UserDTOtoLoginViewModelProfile : Profile
    {
        public UserDTOtoLoginViewModelProfile()
        {
            CreateMap<UserDTO, LoginViewModel>().ReverseMap();
        }
    }
}
