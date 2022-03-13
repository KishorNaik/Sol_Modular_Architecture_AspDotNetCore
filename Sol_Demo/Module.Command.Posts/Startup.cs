using Framework.ASP.Extensions.Extensions;
using Framework.SqlClient.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts
{
    public static class Startup
    {
        public static void AddModuleCommandPost(this IServiceCollection services, IConfiguration configuration = default)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            string connetionString = configuration?.GetConnectionString("UserDB")!;

            services.AddSqlProvider(connetionString);
            services.AddFluentValidationFilter(typeof(Startup));
        }
    }
}