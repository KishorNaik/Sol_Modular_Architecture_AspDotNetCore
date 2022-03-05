using AutoMapper;
using Dapper;
using Framework.SqlClient.Helper;
using MediatR;
using Module.Query.User.DTO.Request;
using Module.Query.User.DTO.Response;
using Module.Query.User.Infrastructures.Abstracts;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Infrastructures.DataService
{
    public class AuthUserDataService : AuthUserRequestDTO, IRequest<AuthUserResponseDTO>
    {
    }

    public sealed class AuthUserDataServiceHandler : UserQueryDataServiceAbstract, IRequestHandler<AuthUserDataService, AuthUserResponseDTO>
    {
        private readonly ISqlClientDbProvider? sqlClientDbProvider;
        private readonly IMapper? mapper = null;

        public AuthUserDataServiceHandler(ISqlClientDbProvider sqlClientDbProvider, IMapper mapper)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
            this.mapper = mapper;
        }

        Task<AuthUserResponseDTO>? IRequestHandler<AuthUserDataService, AuthUserResponseDTO>.Handle(AuthUserDataService request, CancellationToken cancellationToken)
        {
            try
            {
                var dynamicParameterTask = base.GetParametersAsync("Auth", mapper?.Map<UserModel>(request));

                return sqlClientDbProvider
                           ?.DapperBuilder
                           ?.OpenConnection(this.sqlClientDbProvider.GetConnection())
                           ?.Parameter(async () => await dynamicParameterTask)
                           ?.Command(async (dbConnection, dynamicParameter) =>
                           {
                               var result = await dbConnection
                                                  .QueryFirstAsync<UserModel>("uspGetUser", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                               return this?.mapper?.Map<AuthUserHashPasswordResponseDTO>(result);
                           })
                           ?.ResultAsync<AuthUserResponseDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}