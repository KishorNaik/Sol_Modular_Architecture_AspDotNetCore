using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Command.Posts.Applications.Features;
using Module.Command.Posts.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.Controllers
{
    [Produces("application/json")]
    [Route("api/post")]
    public class PostCommandController : ControllerBase
    {
        private readonly IMapper? mapper = null;
        private readonly IMediator? mediator = null;

        public PostCommandController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestDTO createPostRequestDTO) =>
            base.Ok(await this?.mediator?.Send<bool>(this?.mapper?.Map<CreatePostCommand>(createPostRequestDTO)!)!);
    }
}