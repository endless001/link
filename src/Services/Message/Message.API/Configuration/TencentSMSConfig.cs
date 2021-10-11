using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Configuration
{
    public class TencentSMSConfig
    {
        public string Url { get; set; }
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string Sign { get; set; }
    }
}
