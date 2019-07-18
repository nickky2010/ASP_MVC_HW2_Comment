using ASP_MVC_HW2_Comment.DAL.Models;
using ASP_MVC_HW2_Comment.Models;
using AutoMapper;

namespace BLL.Infrastructure.Mapping.Profiles.DTOtoModel
{
    public class CommentDTOtoModelProfile : Profile
    {
        public CommentDTOtoModelProfile()
        {
            CreateMap<Comment, CommentDTO>()
                .ForPath(dest => dest.UserProfileDTO.Id, opts => opts.MapFrom(m => m.UserProfileId))
                .ForPath(dest => dest.UserProfileDTO.Firstname, opts => opts.MapFrom(m => m.UserProfile.Firstname))
                .ForPath(dest => dest.UserProfileDTO.Lastname, opts => opts.MapFrom(m => m.UserProfile.Lastname));
            CreateMap<CommentDTO, Comment>()
                .ForPath(dest => dest.UserProfileId, opts => opts.MapFrom(m => m.UserProfileDTO.Id))
                .ForPath(dest => dest.UserProfile.Firstname, opts => opts.MapFrom(m => m.UserProfileDTO.Firstname))
                .ForPath(dest => dest.UserProfile.Lastname, opts => opts.MapFrom(m => m.UserProfileDTO.Lastname));
        }
    }
}
