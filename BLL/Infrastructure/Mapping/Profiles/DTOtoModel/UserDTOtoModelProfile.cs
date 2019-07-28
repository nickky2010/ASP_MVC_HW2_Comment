using ASP_MVC_HW2_Comment.DAL.Models.Account;
using ASP_MVC_HW2_Comment.Models.Account;
using AutoMapper;

namespace BLL.Infrastructure.Mapping.Profiles.DTOtoModel
{
    public class UserDTOtoModelProfile : Profile
    {
        public UserDTOtoModelProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
