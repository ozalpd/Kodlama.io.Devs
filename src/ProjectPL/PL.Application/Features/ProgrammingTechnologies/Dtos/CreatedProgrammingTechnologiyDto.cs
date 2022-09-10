using PL.Domain.Enums;

namespace PL.Application.Features.ProgrammingTechnologies.Dtos
{
    /// <summary>
    /// Response model of CreateTechnologyCommand
    /// </summary>
    public class CreatedProgrammingTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProgrammingTechType TechnologyType { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
