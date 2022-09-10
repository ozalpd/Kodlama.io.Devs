using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.ProgrammingTechnologies.Dtos;
using PL.Application.Features.ProgrammingTechnologies.Rules;
using PL.Application.Services.Repositories;

namespace PL.Application.Features.ProgrammingTechnologies.Queries.GetById
{
    /// <summary>
    /// Brings a ProgrammingTechnology record by its Id
    /// </summary>
    public class GetByIdTechnologyQuery : IRequest<GetByIdProgrammingTechnologyDto>
    {
        public int Id { get; set; }


        /// <summary>
        /// Handler of GetByIdTechnologyCommand
        /// </summary>
        public class GetByIdTechnologyCommandHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public GetByIdTechnologyCommandHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetByIdProgrammingTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetAsync(l => l.Id == request.Id,
                                                        include: pt => pt.Include(pt => pt.ProgrammingLanguage),
                                                        enableTracking: false);
                _businessRules.ShouldExist(entity);

                var dto = _mapper.Map<GetByIdProgrammingTechnologyDto>(entity);
                return dto;
            }
        }
    }
}
