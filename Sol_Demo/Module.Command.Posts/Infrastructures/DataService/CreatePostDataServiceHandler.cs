using AutoMapper;
using Dapper;
using Framework.SqlClient.Helper;
using MediatR;
using Module.Command.Posts.DTO.Requests;
using Module.Command.Posts.Infrastructures.Abstracts;
using Module.Shared.Entity.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.Infrastructures.DataService
{
    public class CreatePostDataService : CreatePostRequestDTO, IRequest<bool>
    {
    }

    public sealed class CreatePostDataServiceHandler : PostCommandDataServiceAbstract, IRequestHandler<CreatePostDataService, bool>
    {
        private readonly ISqlClientDbProvider? sqlClientDbProvider = null;
        private readonly IMapper? mapper = null;

        public CreatePostDataServiceHandler(ISqlClientDbProvider sqlClientDbProvider, IMapper mapper)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
            this.mapper = mapper;
        }

        Task<bool> IRequestHandler<CreatePostDataService, bool>.Handle(CreatePostDataService request, CancellationToken cancellationToken)
        {
            try
            {
                var dynamaicParameterTask = base.SetParametersAsync("Post-Create", this?.mapper?.Map<PostsModel>(request)!);

                return this?.sqlClientDbProvider
                            ?.DapperBuilder
                            ?.OpenConnection(this.sqlClientDbProvider.GetConnection())
                            ?.Parameter(async () => await dynamaicParameterTask)
                            ?.Command(async (dbConnection, dynamicParameter) =>
                            {
                                int status = await dbConnection
                                                    .ExecuteAsync("uspSetUserPost", param: dynamicParameter, commandType: System.Data.CommandType.StoredProcedure);

                                return (status >= 1) ? true : false;
                            })
                            ?.ResultAsync<bool>()!;
            }
            catch
            {
                throw;
            }
        }
    }
}