using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.Model
{
    /// <summary>
    /// Common Response to deteremine Success/Failure of Request
    /// </summary>
    public class DataUpdateResponseDTO
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int RecordCount { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
