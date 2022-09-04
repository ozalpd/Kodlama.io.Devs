using Microsoft.EntityFrameworkCore;
using PL.Domain.Entities;

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
                new (5, "C#", 1000, "C Sharp Programming Language")
            };



            modelBuilder.Entity<ProgrammingLanguage>().HasData(languages);
        }
    }
}
