using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PL.Domain.Entities;

namespace PL.Persistence.Configs
{
    public class ProgrammingLanguageConfig : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired(true)
                                         .HasMaxLength(100);

            builder.HasIndex(p => p.Name).IsUnique(true);

            builder.HasIndex(p => p.DisplayOrder);
            builder.Property(p => p.DisplayOrder).HasDefaultValue(10000);
        }
    }
}
