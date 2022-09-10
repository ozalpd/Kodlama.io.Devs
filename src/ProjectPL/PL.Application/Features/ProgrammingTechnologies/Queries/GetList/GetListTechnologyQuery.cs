using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.ProgrammingTechnologies.Models;
using PL.Application.Features.ProgrammingTechnologies.Rules;
using PL.Application.Services.Repositories;

namespace PL.Application.Features.ProgrammingTechnologies.Queries.GetList
{
    public class GetListTechnologyQuery : IRequest<GetListProgrammingTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }

        /// <summary>
        /// Handler of GetListTechnologyQuery
        /// </summary>
        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, GetListProgrammingTechnologyModel>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public GetListTechnologyQueryHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetListProgrammingTechnologyModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                var pageRequest = request.PageRequest;
                var techs = await _repository.GetListAsync(index: pageRequest.Page,
                                                           size: pageRequest.PageSize,
                                                           orderBy: pt => pt.OrderBy(l => l.Name),
                                                           include: pt => pt.Include(pt => pt.ProgrammingLanguage),
                                                           enableTracking: false /* no need to track */);

                var listModel = _mapper.Map<GetListProgrammingTechnologyModel>(techs);
                return listModel;
            }
        }
    }
}
