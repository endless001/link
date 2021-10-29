using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.API.Configuration
{
    public class StorageConfig
    {
        public string Endpoint { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string BucketStorageName { get; set; }
        public string BucketUserPhotoName { get; set; }
    }
}
