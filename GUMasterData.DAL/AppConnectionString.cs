using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUMasterData.DAL
{
    class AppConnectionString
    {
        /// <summary>
        /// To manage connection string for Data Access Layer Project
        /// </summary>
        private readonly string connectionString;
        public AppConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
