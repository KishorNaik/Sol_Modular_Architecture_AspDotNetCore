using Framework.ASP.Extensions.Extensions;
using Framework.SqlClient.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Shared.Business.Rule.User;

namespace Module.Command.User
{
    public static class Startup
    {
        public static void AddModuleCommandUser(this IServiceCollection services, IConfiguration configuration = default)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            string connetionString = configuration?.GetConnectionString("UserDB")!;

            services.AddSqlProvider(connetionString);

            services.AddScoped<IHashPasswordRule, HashPasswordRule>();

            services.AddFluentValidationFilter(typeof(Startup));
        }
    }
}