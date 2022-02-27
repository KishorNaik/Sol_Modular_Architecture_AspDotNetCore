using Dapper;
using Framework.SqlClient.DataService;
using Module.Shared.Entity.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.Infrastructures.Abstracts
{
    public abstract class UserCommandDataServiceAbstract : CommandDataServiceAbstract<UserModel>
    {
        protected override Task<DynamicParameters> SetParametersAsync(string command, UserModel model)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@UserIdentity", model.UserIdentity, DbType.Guid, ParameterDirection.Input);
                    dynamicParameter.Add("@FirstName", model.FirstName, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@LastName", model.LastName, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@Email", model.Email, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@HashPassword", model.HashPassword, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@Salt", model.Salt, DbType.String, ParameterDirection.Input);

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