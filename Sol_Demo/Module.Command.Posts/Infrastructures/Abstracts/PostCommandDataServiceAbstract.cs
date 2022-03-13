using Dapper;
using Framework.SqlClient.DataService;
using Module.Shared.Entity.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Module.Command.Posts.Infrastructures.Abstracts
{
    public abstract class PostCommandDataServiceAbstract : CommandDataServiceAbstract<PostsModel>
    {
        protected override Task<DynamicParameters> SetParametersAsync(string command, PostsModel model)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@PostIdentity", model?.PostIdentity, DbType.Guid, ParameterDirection.Input);
                    dynamicParameter.Add("@Post", model?.Post, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@UserIdentity", model?.UserIdentity, DbType.Guid, ParameterDirection.Input);

                    return dynamicParameter;
                });
            }
            catch
            {
                throw;
            }
        }
    }
}