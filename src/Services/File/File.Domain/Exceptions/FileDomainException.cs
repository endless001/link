using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.Exceptions
{
    public class FileDomainException : Exception
    {
        public FileDomainException() { }
        public FileDomainException(string message) : base(message) { }
        public FileDomainException(string message, Exception exception) : base(message, exception) { }
    }
}
