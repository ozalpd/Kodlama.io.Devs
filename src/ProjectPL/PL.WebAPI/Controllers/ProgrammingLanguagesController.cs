using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Commands.Delete;
using PL.Application.Features.ProgrammingLanguages.Queries.GetById;
using PL.Application.Features.ProgrammingLanguages.Queries.GetList;

namespace PL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createCommand)
        {
            var result = await Mediator.Send(createCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteCommand)
        {
            int result = await Mediator.Send(deleteCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getListBrandQuery = new GetListLanguageQuery() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
    }
}