using Core.Persistence.Repositories;
using PL.Application.Services.Repositories;
using PL.Domain.Entities;
using PL.Persistence.Contexts;

namespace PL.Persistence.Repositories
{
    public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>,
        IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(BaseDbContext context) : base(context) { }
    }
}
