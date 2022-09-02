using AutoMapper;
using MediatR;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;

namespace PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    /// <summary>
    /// Inserts a ProgrammingLanguage record
    /// </summary>
    public class CreateLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? DisplayOrder { get; set; }


        /// <summary>
        /// Handler of CreateLanguageCommand
        /// </summary>
        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public CreateLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                _businessRules.NameCanNotBeEmpty(request);
                await _businessRules.NameMustBeUnique(request);
                _businessRules.SetDefaultDisplayOrder(request);

                var mappedEntity = _mapper.Map<ProgrammingLanguage>(request);
                var createdEntity = await _repository.AddAsync(mappedEntity);
                var createdDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdEntity);

                return createdDto;
            }
        }
    }
}
