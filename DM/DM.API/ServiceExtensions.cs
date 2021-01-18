using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string dnCors)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(dnCors,
                    builder => builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}
