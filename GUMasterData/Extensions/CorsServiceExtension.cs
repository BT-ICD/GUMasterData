using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.Extensions
{
    public static class CorsServiceExtension
    {
        static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    }
                    );
            });
        }

    }
}
