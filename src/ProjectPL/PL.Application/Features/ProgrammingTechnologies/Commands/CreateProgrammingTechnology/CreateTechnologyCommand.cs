using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.ProgrammingTechnologies.Dtos;
using PL.Application.Features.ProgrammingTechnologies.Rules;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;
using PL.Domain.Enums;

namespace PL.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    /// <summary>
    /// Inserts a ProgrammingTechnology record
    /// </summary>
    public class CreateTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingTechType TechnologyType { get; set; }


        /// <summary>
        /// Handler of CreateTechnologyCommand
        /// </summary>
        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public CreateTechnologyCommandHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedProgrammingTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                _businessRules.NameCanNotBeEmpty(request);
                await _businessRules.NameMustBeUnique(request);

                var mappedEntity = _mapper.Map<ProgrammingTechnology>(request);
                var createdEntity = await _repository.AddAsync(mappedEntity);
                var entity = await _repository.GetAsync(l => l.Id == createdEntity.Id,
                                                        include: pt => pt.Include(pt => pt.ProgrammingLanguage),
                                                        enableTracking: false);
                var createdDto = _mapper.Map<CreatedProgrammingTechnologyDto>(entity);

                return createdDto;
            }
        }
    }
}
