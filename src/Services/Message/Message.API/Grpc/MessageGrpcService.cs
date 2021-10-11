using Grpc.Core;
using Message.API.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Grpc
{
    public  class MessageGrpcService : MessageGrpc.MessageGrpcBase
    {
        private readonly ISMSService _smsService;
        private readonly IMailService _mailService;

        public MessageGrpcService(ISMSService smsService, IMailService mailService)
        {
            _smsService = smsService;
            _mailService = mailService;
        }
        public override Task<MessageReply> SendMail(MailRequest request, ServerCallContext context)
        {
            _mailService.SendMail(request.Address, request.Content);
            return Task.FromResult(new MessageReply() { });
        }

        public override Task<MessageReply> SendSMS(SMSRequest request, ServerCallContext context)
        {
            _smsService.SendSMS(request.Phone, request.NationCode,request.TemplateId,request.Content);
            return Task.FromResult(new MessageReply() { });
        }
    }
}
