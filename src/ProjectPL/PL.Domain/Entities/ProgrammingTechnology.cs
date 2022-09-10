using Core.Persistence.Repositories;
using PL.Domain.Enums;

namespace PL.Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public ProgrammingTechnology() { }

        public ProgrammingTechnology(int id, string name, int programmingLanguageId,
            ProgrammingTechType technologyType, string? description = null) : base(id)
        {
            Name = name;
            Description = description;
            ProgrammingLanguageId = programmingLanguageId;
            TechnologyType = technologyType;
        }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        public ProgrammingTechType TechnologyType { get; set; }
    }
}
