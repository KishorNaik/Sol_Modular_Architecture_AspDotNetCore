using Dapper;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.SqlClient.DataService
{
    public abstract class CommandDataServiceAbstract<TModel> where TModel : BaseEntity
    {
        protected abstract Task<DynamicParameters> SetParametersAsync(string command, TModel model);
    }
}