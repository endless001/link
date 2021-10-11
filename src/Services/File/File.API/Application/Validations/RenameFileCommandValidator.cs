using File.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace File.API.Application.Validations
{
    public class RenameFileCommandValidator : AbstractValidator<RenameFileCommand>
    {
        public RenameFileCommandValidator(ILogger<MoveFileCommand> logger)
        {
            RuleFor(file => file.FileName).NotEmpty();
            RuleFor(file => file.FileName).Custom((file, context) =>
            {
                if (file.Length > 10)
                {
                    context.AddFailure("The list must contain 10 items or fewer");
                }
            });
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
