using Dapper;
using Framework.SqlClient.DataServices;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Module.Query.User.Infrastructures.Abstracts
{
    public abstract class UserQueryDataServiceAbstract : QueryDataServiceAbstract<UserModel>
    {
        protected override Task<DynamicParameters> GetParametersAsync(string? command, UserModel? model = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameter.Add("@Email", model?.Email, DbType.String, ParameterDirection.Input);

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