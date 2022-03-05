using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Module.Query.User.Business.Rule;
using Module.Query.User.DTO.Request;
using Module.Query.User.DTO.Response;
using Module.Query.User.Infrastructures.DataService;
using Module.Shared.Business.Rule.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Applications.Features
{
    public class AuthUserQuery : AuthUserRequestDTO, IRequest<AuthUserResponseDTO>
    {
    }

    public sealed class AuthUserQueryHandler : IRequestHandler<AuthUserQuery, AuthUserResponseDTO>
    {
        private readonly IMapper? mapper = null;
        private readonly IMediator? mediator = null;
        private readonly IHashPasswordRule? hashPassword = null;
        private readonly IGenerateJwtTokenRule? generateJwtTokenRule = null;

        public AuthUserQueryHandler(
                IMapper? mapper,
                IMediator? mediator,
                IHashPasswordRule? hashPasswordRule,
                IGenerateJwtTokenRule generateJwtTokenRule
            )
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.hashPassword = hashPasswordRule;
            this.generateJwtTokenRule = generateJwtTokenRule;
        }

        async Task<AuthUserResponseDTO> IRequestHandler<AuthUserQuery, AuthUserResponseDTO>.Handle(AuthUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get User Response Details from the repository
                AuthUserResponseDTO? result = await this?.mediator?.Send<AuthUserResponseDTO>(this?.mapper?.Map<AuthUserDataService>(request)!)!;

                // Cast
                AuthUserHashPasswordResponseDTO authUserHashPasswordResponseDTO = (result as AuthUserHashPasswordResponseDTO)!;

                // Password Validation
                bool? isPasswordValidate = await this?.hashPassword?.ValidatePassword(request?.Password, authUserHashPasswordResponseDTO?.Salt, authUserHashPasswordResponseDTO?.Hash)!;

                if (isPasswordValidate == true)
                {
                    // Generate Jwt Token
                    result.Jwt = new JwtResponse();
                    result.Jwt.Token = await this?.generateJwtTokenRule?.Token(authUserHashPasswordResponseDTO!)!;
                    authUserHashPasswordResponseDTO!.Salt = null;
                    authUserHashPasswordResponseDTO!.Hash = null;
                }
                else
                {
                    throw new Exception("User Name & password does not match");
                }

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}