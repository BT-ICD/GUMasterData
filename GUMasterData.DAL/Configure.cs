using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUMasterData.DAL
{
    /// <summary>
    /// To inject connection string as a depedency injection. 
    /// To provide object of AppConnectionString as a dependency injection
    /// </summary>
    public class Configure
    {

        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddSingleton<AppConnectionString>(new AppConnectionString(connectionString));
        }
    }
}
