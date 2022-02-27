using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Command.User.Applications.Features;
using Module.Command.User.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserCommandController : ControllerBase
    {
        private readonly IMediator mediator = null;
        private readonly IMapper mapper = null;

        public UserCommandController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO createUserRequestDTO)
        {
            try
            {
                return base.Ok(await mediator.Send<bool>(this.mapper.Map<CreateUserCommand>(createUserRequestDTO)));
            }
            catch
            {
                throw;
            }
        }
    }
}