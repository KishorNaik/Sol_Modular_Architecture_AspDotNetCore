using Framework.Api.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFrameworkApi(this IServiceCollection services, IConfiguration configuration = default)
        {
            services.AddControllers()
                       .ConfigureApplicationPartManager((manager) =>
                       {
                           manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                       });

            return services;
        }
    }
}