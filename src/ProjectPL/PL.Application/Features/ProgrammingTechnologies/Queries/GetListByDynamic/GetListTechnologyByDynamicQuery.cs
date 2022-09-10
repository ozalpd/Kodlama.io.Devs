using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PL.Application.Features.ProgrammingTechnologies.Models;
using PL.Application.Features.ProgrammingTechnologies.Rules;
using PL.Application.Services.Repositories;

namespace PL.Application.Features.ProgrammingTechnologies.Queries.GetListByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<GetListProgrammingTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }


        public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, GetListProgrammingTechnologyModel>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public GetListTechnologyByDynamicQueryHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetListProgrammingTechnologyModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                var pageRequest = request.PageRequest;
                var techs = await _repository.GetListByDynamicAsync(request.Dynamic,
                                                                    include: pt => pt.Include(pt => pt.ProgrammingLanguage),
                                                                    index: pageRequest.Page,
                                                                    size: pageRequest.PageSize,
                                                                    enableTracking: false);

                var listModel = _mapper.Map<GetListProgrammingTechnologyModel>(techs);
                return listModel;
            }
        }
    }
}
