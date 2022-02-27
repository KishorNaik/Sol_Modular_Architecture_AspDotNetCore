using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Entity;

namespace Framework.SqlClient.DataServices
{
    public abstract class QueryDataServiceAbstract<TModel> where TModel : BaseEntity
    {
        protected abstract Task<DynamicParameters> GetParametersAsync(string command, TModel model = default);
    }
}