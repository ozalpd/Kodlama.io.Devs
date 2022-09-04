using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Models;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application.Features.ProgrammingLanguages.Queries.GetList
{
    public class GetListLanguageQuery : IRequest<GetListProgrammingLanguageModel>
    {
        public PageRequest PageRequest { get; set; }

        /// <summary>
        /// Handler of GetListLanguageQuery
        /// </summary>
        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListProgrammingLanguageModel>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public GetListLanguageQueryHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetListProgrammingLanguageModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                var pageRequest = request.PageRequest;
                var languages = await _repository.GetListAsync(index: pageRequest.Page,
                                                               size: pageRequest.PageSize,
                                                               orderBy: pl => pl.OrderBy(l => l.DisplayOrder)
                                                                                .ThenBy(l => l.Name),
                                                               enableTracking: false /* no need to track */);

                var listModel = _mapper.Map<GetListProgrammingLanguageModel>(languages);
                return listModel;
            }
        }
    }
}
