using AutoMapper;
using Core.Persistence.Paging;
using PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Dtos;
using PL.Application.Features.ProgrammingLanguages.Models;
using PL.Domain.Entities;

namespace PL.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetListProgrammingLanguageDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, GetListProgrammingLanguageModel>().ReverseMap();
        }
    }
}
