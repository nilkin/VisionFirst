using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator _mediator;
    }
}