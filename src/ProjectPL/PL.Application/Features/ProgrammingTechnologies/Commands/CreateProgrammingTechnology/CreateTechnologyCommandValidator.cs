using FluentValidation;

namespace PL.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateTechnologyCommandValidator: AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MaximumLength(100);
        }
    }
}
