using Core.CrossCuttingConcerns.Exceptions;
using PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using PL.Application.Services.Repositories;

namespace PL.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository repository)
        {
            _repository = repository;
        }
        private readonly IProgrammingLanguageRepository _repository;

        public void NameCanNotBeEmpty(CreateLanguageCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new BusinessException("ProgrammingLanguage name cannot be empty!");
        }

        public async Task NameMustBeUnique(CreateLanguageCommand request)
        {
            bool result = await _repository.AnyAsync(b => b.Name == request.Name);
            if (result)
                throw new BusinessException("ProgrammingLanguage name exists!");
        }

        public void SetDefaultDisplayOrder(CreateLanguageCommand request)
        {
            if (request.DisplayOrder == null)
                request.DisplayOrder = 10000;
        }
    }
}
