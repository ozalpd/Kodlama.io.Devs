using AutoMapper;
using MediatR;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Services.Repositories;

namespace PL.Application.Features.ProgrammingLanguages.Queries.GetById
{
    /// <summary>
    /// Brings a ProgrammingLanguage record by its Id
    /// </summary>
    public class GetByIdLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
    {
        public int Id { get; set; }


        /// <summary>
        /// Handler of GetByIdLanguageCommand
        /// </summary>
        public class GetByIdLanguageCommandHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public GetByIdLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetAsync(l => l.Id == request.Id);
                _businessRules.ShouldExist(entity);

                var dto = _mapper.Map<GetByIdProgrammingLanguageDto>(entity);
                return dto;
            }
        }
    }
}
