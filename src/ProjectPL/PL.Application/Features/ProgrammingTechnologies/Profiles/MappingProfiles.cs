using AutoMapper;
using Core.Persistence.Paging;
using PL.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using PL.Application.Features.ProgrammingTechnologies.Dtos;
using PL.Application.Features.ProgrammingTechnologies.Models;
using PL.Domain.Entities;

namespace PL.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ForMember(dto => dto.ProgrammingLanguageName,
                                                                                          opt => opt.MapFrom(t => t.ProgrammingLanguage.Name))
                                                                               .ReverseMap();
            CreateMap<ProgrammingTechnology, GetByIdProgrammingTechnologyDto>().ForMember(dto => dto.ProgrammingLanguageName,
                                                                                          opt => opt.MapFrom(t => t.ProgrammingLanguage.Name))
                                                                               .ReverseMap();
            CreateMap<ProgrammingTechnology, GetListProgrammingTechnologyDto>().ForMember(dto => dto.ProgrammingLanguageName,
                                                                                          opt => opt.MapFrom(t => t.ProgrammingLanguage.Name))
                                                                               .ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnology>, GetListProgrammingTechnologyModel>().ReverseMap();
        }
    }
}
