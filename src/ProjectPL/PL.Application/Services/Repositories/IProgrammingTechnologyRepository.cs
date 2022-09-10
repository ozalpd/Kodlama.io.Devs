using Core.Persistence.Repositories;
using PL.Domain.Entities;

namespace PL.Application.Services.Repositories
{
    public interface IProgrammingTechnologyRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
    {
    }
}
