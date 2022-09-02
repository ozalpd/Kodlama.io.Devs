using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using PL.Application.Features.ProgrammingLanguages.Commands.Delete;

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
    }
}