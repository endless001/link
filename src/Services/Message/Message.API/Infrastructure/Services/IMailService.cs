﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Infrastructure.Services
{
    public interface IMailService
    {
        Task<bool> SendMail(string address, string content);
    }
}
