using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Infrastructure.Services
{
    public interface ISMSService
    {

        Task<bool> SendSMS(string phone, int nationCode, int templateId, IEnumerable<string> content);
    }
}
