using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PL.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator
        {
            get
            {
               if(_mediator == null)
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();

               return _mediator;
            }
        }
        private IMediator? _mediator;
    }
}
