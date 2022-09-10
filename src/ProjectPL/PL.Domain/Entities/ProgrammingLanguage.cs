using Core.Persistence.Repositories;

namespace PL.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public ProgrammingLanguage()
        {
            ProgrammingTechnologies = new HashSet<ProgrammingTechnology>();
        }

        public ProgrammingLanguage(int id, string name,
            int? displayOrder = null, string? description = null) : base(id)
        {
            Name = name;
            Description = description;
            DisplayOrder = displayOrder ?? 10000;
            ProgrammingTechnologies = new HashSet<ProgrammingTechnology>();
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }

        public ICollection<ProgrammingTechnology> ProgrammingTechnologies { get; set; }
    }
}