using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM.API.Model
{
    public class DmResponse
    {
        public string ResponseCode { get; set; }
        public dynamic ResponseBody { get; set; }
    }
}
