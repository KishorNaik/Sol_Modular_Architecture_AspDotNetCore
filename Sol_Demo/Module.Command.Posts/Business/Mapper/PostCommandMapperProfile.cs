using AutoMapper;
using Module.Command.Posts.Applications.Features;
using Module.Command.Posts.DTO.Requests;
using Module.Command.Posts.Infrastructures.DataService;
using Module.Shared.Entity.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.Business.Mapper
{
    public class PostCommandMapperProfile : Profile
    {
        public PostCommandMapperProfile()
        {
            base.CreateMap<CreatePostCommand, CreatePostDataService>();
            base.CreateMap<CreatePostDataService, PostsModel>();
        }
    }
}