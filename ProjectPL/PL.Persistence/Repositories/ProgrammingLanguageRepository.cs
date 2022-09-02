using Core.Persistence.Repositories;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;
using PL.Persistence.Contexts;

namespace PL.Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>,
        IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context) { }
    }
}
