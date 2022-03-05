using AutoMapper;
using Module.Query.User.Applications.Features;
using Module.Query.User.DTO.Request;
using Module.Query.User.DTO.Response;
using Module.Query.User.Infrastructures.DataService;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Business.Mapper
{
    public class UserQueryMapperProfile : Profile
    {
        public UserQueryMapperProfile()
        {
            base.CreateMap<AuthUserRequestDTO, UserModel>()
                    .ForMember((dest) => dest.HashPassword,
                              (opt) => opt.MapFrom((src) => src.Password)
                             );

            base.CreateMap<UserModel, AuthUserHashPasswordResponseDTO>()
                .ForMember((dest) => dest.Hash,
                           (opt) => opt.MapFrom((src) => src.HashPassword))
                .ForMember((dest) => dest.EmailId,
                            (opt) => opt.MapFrom((src) => src.Email)
                            );

            base.CreateMap<AuthUserHashPasswordResponseDTO, AuthUserResponseDTO>();
            base.CreateMap<AuthUserRequestDTO, AuthUserQuery>();
            base.CreateMap<AuthUserQuery, AuthUserDataService>();
        }
    }
}