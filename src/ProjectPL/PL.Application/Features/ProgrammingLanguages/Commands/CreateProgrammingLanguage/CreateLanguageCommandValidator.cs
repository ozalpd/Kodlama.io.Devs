using FluentValidation;

namespace PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateLanguageCommandValidator: AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MaximumLength(100);
        }
    }
}
