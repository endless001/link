using Message.API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Message.API.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly MailConfig _mailConfig;
        public MailService(SmtpClient smtpClient, MailConfig mailConfig)
        {
            _smtpClient = smtpClient;
            _mailConfig = mailConfig;
        }
        public async Task<bool> SendMail(string address, string content)
        {

            string subject = _mailConfig.Subject;
            MailMessage message = new MailMessage()
            {
                From = new MailAddress(_mailConfig.Address, _mailConfig.DisplayName),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(address));
            await _smtpClient.SendMailAsync(message);
            return true;
        }
    }
}
