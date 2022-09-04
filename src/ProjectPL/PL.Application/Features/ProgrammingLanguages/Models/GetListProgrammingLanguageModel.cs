using Core.Persistence.Paging;
using PL.Application.Features.ProgrammingLanguages.Dtos;

namespace PL.Application.Features.ProgrammingLanguages.Models
{
    /// <summary>
    /// Response model of GetListLanguageQuery
    /// </summary>
    public class GetListProgrammingLanguageModel : BasePageableModel
    {
        public IList<GetListProgrammingLanguageDto> Items { get; set; }
    }
}
