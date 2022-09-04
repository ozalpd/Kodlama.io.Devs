using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PL.Domain.Entities;
using PL.Persistence.Configs;
using System.Reflection;

namespace PL.Persistence.Contexts
{
    public partial class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Brings and applies all entity configuration classes when model builder generates a migration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

            //I think it's a good idea to keep table names together. Ozalp 2022-09-02
            modelBuilder.Entity<ProgrammingLanguage>().ToTable("ProgrammingLanguages");


            DataSample.Seed(modelBuilder);
        }
    }
}
