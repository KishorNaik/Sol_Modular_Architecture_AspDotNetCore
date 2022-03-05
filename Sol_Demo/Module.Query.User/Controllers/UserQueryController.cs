using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Query.User.Applications.Features;
using Module.Query.User.DTO.Request;
using Module.Query.User.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    internal class UserQueryController : ControllerBase
    {
        private readonly IMediator? mediator = null;
        private readonly IMapper? mapper = null;

        public UserQueryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthUserRequestDTO authUserRequestDTO)
        {
            try
            {
                AuthUserResponseDTO result = await this?.mediator?.Send<AuthUserResponseDTO>(this?.mapper?.Map<AuthUserQuery>(authUserRequestDTO)!)!;

                return base.Ok(result);
            }
            catch
            {
                throw;
            }
        }
    }
}