using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PL.Domain.Entities;

namespace PL.Persistence.Configs
{
    public class ProgrammingTechnologyConfig : IEntityTypeConfiguration<ProgrammingTechnology>
    {
        public void Configure(EntityTypeBuilder<ProgrammingTechnology> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired(true)
                                         .HasMaxLength(100);
            builder.HasIndex(p => p.Name).IsUnique(true);
            builder.HasIndex(p => p.TechnologyType);
        }
    }
}
