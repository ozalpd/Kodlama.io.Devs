using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using PL.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using PL.Application.Features.ProgrammingTechnologies.Commands.Delete;
using PL.Application.Features.ProgrammingTechnologies.Queries.GetById;
using PL.Application.Features.ProgrammingTechnologies.Queries.GetList;
using PL.Application.Features.ProgrammingTechnologies.Queries.GetListByDynamic;

namespace PL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammingTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createCommand)
        {
            var result = await Mediator.Send(createCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteCommand)
        {
            int result = await Mediator.Send(deleteCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getListBrandQuery = new GetListTechnologyQuery() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListByDynamic = new()
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };

            var result = await Mediator.Send(getListByDynamic);
            return Ok(result);
        }
    }
}