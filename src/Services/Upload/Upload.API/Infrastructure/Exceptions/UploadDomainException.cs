using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.API.Infrastructure.Exceptions
{
    public class UploadDomainException: Exception
    {
        public UploadDomainException()
        { }

        public UploadDomainException(string message)
          : base(message)
        { }

        public UploadDomainException(string message, Exception innerException)
          : base(message, innerException)
        { }
    }
}

