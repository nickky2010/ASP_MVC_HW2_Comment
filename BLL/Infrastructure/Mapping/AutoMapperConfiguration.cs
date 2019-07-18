using AutoMapper;
using BLL.Infrastructure.Mapping.Profiles.DTOtoModel;
using BLL.Infrastructure.Mapping.Profiles.DTOtoViewModel;
using System;

namespace BLL.Infrastructure.Mapping
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
            });
        }
    }
}
