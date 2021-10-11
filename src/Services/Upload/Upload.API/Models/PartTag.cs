using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.API.Models
{
    public class PartTag
    {
        public int PartNumber { get; set; }
        public string ETag { get; set; }
        public string Crc64 { get; }
        public long Length { get; }
    }
}
