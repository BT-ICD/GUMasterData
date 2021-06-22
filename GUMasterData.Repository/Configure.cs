using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUMasterData.Repository
{
    /// <summary>
    /// To inject repository as a depedency injection. 
    /// To provide object of particular repository as a dependency injection
    /// </summary>

    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            DAL.Configure.ConfigureServices(services, connectionString);

        }
    }
}
