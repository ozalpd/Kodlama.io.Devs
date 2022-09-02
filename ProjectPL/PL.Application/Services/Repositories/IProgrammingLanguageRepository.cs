using Core.Persistence.Repositories;
using PL.Domain.Entities;

namespace PL.Application.Services.Repositories
{
    public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>, IRepository<ProgrammingLanguage>
    {
    }
}
