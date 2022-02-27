using AutoMapper;
using MediatR;
using Module.Command.User.Business.Rule;
using Module.Command.User.DTO.Request;
using Module.Command.User.Infrastructures.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.Applications.Features
{
    public class CreateUserCommand : CreateUserRequestDTO, IRequest<bool>
    {
    }

    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IMediator? mediator = null;
        private readonly IHashPasswordRule? hashPasswordRule = null;

        public CreateUserCommandHandler(IMediator? mediator, IHashPasswordRule? hashPasswordRule)
        {
            this.mediator = mediator;
            this.hashPasswordRule = hashPasswordRule;
        }

        async Task<bool> IRequestHandler<CreateUserCommand, bool>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                (string? salt, string? hash) = await hashPasswordRule?.CreatePasswordAsync(request?.Password)!;

                return await this?.mediator?.Send<bool>(new CreateUserDataService()
                {
                    FirstName = request?.FirstName,
                    LastName = request?.LastName,
                    Email = request?.Email,
                    Password = hash,
                    Salt = salt
                }, cancellationToken)!;
            }
            catch
            {
                throw;
            }
        }
    }
}