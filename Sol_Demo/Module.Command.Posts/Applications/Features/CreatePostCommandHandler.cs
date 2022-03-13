using AutoMapper;
using MediatR;
using Module.Command.Posts.DTO.Requests;
using Module.Command.Posts.Infrastructures.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.Applications.Features
{
    public class CreatePostCommand : CreatePostRequestDTO, IRequest<bool>
    {
    }

    public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IMediator? mediator = null;
        private readonly IMapper? mapper = null;

        public CreatePostCommandHandler(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        Task<bool> IRequestHandler<CreatePostCommand, bool>.Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return this?.mediator?.Send<bool>(this?.mapper?.Map<CreatePostDataService>(request)!)!;
            }
            catch
            {
                throw;
            }
        }
    }
}