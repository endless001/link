using FluentValidation;
using Microsoft.Extensions.Logging;
using File.API.Application.Commands;

namespace File.API.Application.Validations
{
    public class MoveFileCommandValidator : AbstractValidator<MoveFileCommand>
    {
        public MoveFileCommandValidator(ILogger<MoveFileCommand> logger)
        {
            RuleFor(file => file.Path).NotEmpty();
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
