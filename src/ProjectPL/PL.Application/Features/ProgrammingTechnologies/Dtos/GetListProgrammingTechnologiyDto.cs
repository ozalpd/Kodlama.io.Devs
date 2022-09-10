using PL.Domain.Enums;

namespace PL.Application.Features.ProgrammingTechnologies.Dtos
{
    public class GetListProgrammingTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProgrammingTechType TechnologyType { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
