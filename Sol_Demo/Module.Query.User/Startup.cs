using AuthJwt.Generates;
using Framework.ASP.Extensions.Extensions;
using Framework.SqlClient.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Query.User.Business.Rule;
using Module.Shared.Business.Rule.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User
{
    public static class Startup
    {
        public static void AddModuleQueryUser(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            string connetionString = configuration?.GetConnectionString("UserDB")!;

            services.AddSqlProvider(connetionString);

            services.AddScoped<IHashPasswordRule, HashPasswordRule>();
            services.AddScoped<IGenerateJwtTokenRule, GenerateJwtTokenRule>((factory) =>
            {
                IGenerateJwtToken generateJwtToken = factory.GetRequiredService<IGenerateJwtToken>();

                string? secretKey = configuration?.GetValue<string>("SecretKey");

                return new GenerateJwtTokenRule(generateJwtToken, secretKey);
            });

            services.AddFluentValidationFilter(typeof(Startup));
        }
    }
}