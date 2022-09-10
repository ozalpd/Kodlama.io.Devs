using Core.Persistence.Paging;
using PL.Application.Features.ProgrammingTechnologies.Dtos;

namespace PL.Application.Features.ProgrammingTechnologies.Models
{
    /// <summary>
    /// Response model of GetListTechnologyQuery
    /// </summary>
    public class GetListProgrammingTechnologyModel : BasePageableModel
    {
        public IList<GetListProgrammingTechnologyDto> Items { get; set; }
    }
}
