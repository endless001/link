using File.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Application.Validations
{
    public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator(ILogger<CreateFileCommandValidator> logger)
        {
            RuleFor(file => file.IsDirectory).NotEmpty();
            RuleFor(file => file.UserId).NotEmpty();
            
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
