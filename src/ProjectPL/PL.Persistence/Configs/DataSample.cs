using Microsoft.EntityFrameworkCore;
using PL.Domain.Entities;
using PL.Domain.Enums;

namespace PL.Persistence.Configs
{
    public static class DataSample
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            ProgrammingLanguage[] languages =
            {
                new (1, "C", description: "C Programming Language"),
                new (2, "C++"),
                new (3, "Java"),
                new (4, "Objective C", description: "Objective C from Steve Job's Next Step"),
                new (5, "C#", 1000, "C Sharp Programming Language"),
                new (6, "JavaScript", 2000, "A programming language which was intended to work in clientside HTML.")
            };

            ProgrammingTechnology[] techs =
            {
                new (1, "jQuery", 6, ProgrammingTechType.Library, "Most mature JavaScript library."),
                new (2, "Angular JS", 6, ProgrammingTechType.Framework),
                new (3, "WPF", 5, ProgrammingTechType.Framework),
                new (4, "Cocoa", 4, ProgrammingTechType.API, "Apple's native object-oriented application programming interface (API) for its desktop operating system macOS."),
                new (5, "Spring", 3, ProgrammingTechType.Framework, "An application framework and inversion of control container for the Java platform.")
            };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(languages);
            modelBuilder.Entity<ProgrammingTechnology>().HasData(techs);
        }
    }
}
