using AutoMapper;
using Module.Command.User.Applications.Features;
using Module.Command.User.DTO.Request;
using Module.Command.User.Infrastructures.DataService;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.Business.Mapper
{
    public class UserCommandMapperProfile : Profile
    {
        public UserCommandMapperProfile()
        {
            base.CreateMap<CreateUserRequestDTO, CreateUserCommand>();

            base.CreateMap<CreateUserDataService, UserModel>()
                   .ForMember((dest) => dest.HashPassword,
                              (opt) => opt.MapFrom((src) => src.Password)
                             );
        }
    }
}