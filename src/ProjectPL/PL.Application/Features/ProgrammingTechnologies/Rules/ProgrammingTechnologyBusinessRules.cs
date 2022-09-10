using Core.CrossCuttingConcerns.Exceptions;
using PL.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;

namespace PL.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository repository)
        {
            _repository = repository;
        }
        private readonly IProgrammingTechnologyRepository _repository;

        public void NameCanNotBeEmpty(CreateTechnologyCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new BusinessException("ProgrammingTechnology name cannot be empty!");
        }

        public async Task NameMustBeUnique(CreateTechnologyCommand request)
        {
            bool result = await _repository.AnyAsync(b => b.Name == request.Name);
            if (result)
                throw new BusinessException("ProgrammingTechnology name exists!");
        }

        public void ShouldExist(ProgrammingTechnology? programmingTechnology)
        {
            if (programmingTechnology == null)
                throw new BusinessException("ProgrammingTechnology does not exist!");
        }
    }
}
