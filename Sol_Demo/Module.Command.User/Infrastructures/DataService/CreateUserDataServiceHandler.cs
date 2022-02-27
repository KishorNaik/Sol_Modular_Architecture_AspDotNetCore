using AutoMapper;
using Dapper;
using Framework.SqlClient.Helper;
using MediatR;
using Module.Command.User.DTO.Request;
using Module.Command.User.Infrastructures.Abstracts;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Module.Command.User.Infrastructures.DataService
{
    public class CreateUserDataService : CreateUserRequestDTO, IRequest<bool>
    {
        public string? Salt { get; set; }
    }

    public sealed class CreateUserDataServiceHandler : UserCommandDataServiceAbstract, IRequestHandler<CreateUserDataService, bool>
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;
        private readonly IMapper mapper = null;

        public CreateUserDataServiceHandler(ISqlClientDbProvider sqlClientDbProvider, IMapper mapper)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
            this.mapper = mapper;
        }

        Task<bool> IRequestHandler<CreateUserDataService, bool>.Handle(CreateUserDataService request, CancellationToken cancellationToken)
        {
            try
            {
                var dynamicParameterTask = base.SetParametersAsync("User-Create", mapper.Map<UserModel>(request));

                return this.sqlClientDbProvider
                           .DapperBuilder
                           .OpenConnection(this.sqlClientDbProvider.GetConnection())
                           .Parameter(async () => await dynamicParameterTask)
                           .Command(async (dbConnection, dynamicParameter) =>
                           {
                               int status = await dbConnection
                                                .ExecuteAsync("uspSetUser", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                               return (status >= 1) ? true : false;
                           })
                           .ResultAsync<bool>();
            }
            catch
            {
                throw;
            }
        }
    }
}