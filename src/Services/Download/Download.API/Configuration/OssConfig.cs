using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Download.API.Configuration
{
    public class OssConfig
    {
        public string Endpoint { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string BucketNameStorage { get; set; }
        public string BucketNameUserPhoto { get; set; }
    }
}
