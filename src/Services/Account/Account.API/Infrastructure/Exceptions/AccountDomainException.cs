using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Infrastructure.Exceptions
{
    public class AccountDomainException: Exception
    {
        public AccountDomainException()
        { }

        public AccountDomainException(string message)
          : base(message)
        { }

        public AccountDomainException(string message, Exception innerException)
          : base(message, innerException)
        { }
    }
}
