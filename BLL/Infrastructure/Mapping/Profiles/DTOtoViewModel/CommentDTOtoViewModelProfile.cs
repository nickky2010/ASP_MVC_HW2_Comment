using ASP_MVC_HW2_Comment.Models;
using AutoMapper;
using BLL.Models.ViewModel;

namespace BLL.Infrastructure.Mapping.Profiles.DTOtoViewModel
{
    public class CommentDTOtoViewModelProfile : Profile
    {
        public CommentDTOtoViewModelProfile()
        {
            CreateMap<CommentDTO, CommentViewModel>()
                .ForPath(dest => dest.Firstname, opts => opts.MapFrom(m => m.UserProfileDTO.Firstname))
                .ForPath(dest => dest.Lastname, opts => opts.MapFrom(m => m.UserProfileDTO.Lastname));
            CreateMap<CommentViewModel, CommentDTO>()
                .ForPath(dest => dest.UserProfileDTO.Firstname, opts => opts.MapFrom(m => m.Firstname))
                .ForPath(dest => dest.UserProfileDTO.Lastname, opts => opts.MapFrom(m => m.Lastname));

        }
    }
}
