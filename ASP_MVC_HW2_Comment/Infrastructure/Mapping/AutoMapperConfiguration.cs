using ASP_MVC_HW2_Comment.Infrastructure.Mapping.Profiles.DTOtoViewModel;
using AutoMapper;
using BLL.Infrastructure.Mapping.Profiles.DTOtoModel;
using BLL.Infrastructure.Mapping.Profiles.DTOtoViewModel;
using System;

namespace ASP_MVC_HW2_Comment.Infrastructure.Mapping
{
    public class AutoMapperConfiguration
    {
        [Obsolete]
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new CommentDTOtoModelProfile());
                cfg.AddProfile(new RoleDTOtoModelProfile());
                cfg.AddProfile(new UserDTOtoModelProfile());
                cfg.AddProfile(new CommentDTOtoViewModelProfile());
                cfg.AddProfile(new UserDTOtoRegisterViewModelProfile());
                cfg.AddProfile(new UserDTOtoLoginViewModelProfile());
            });
        }
    }
}
