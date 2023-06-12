using Application.Feature.Departments.Dtos;
using Application.Feature.Departments.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : BaseApiController
    {
        public async Task<IActionResult> List()
        {
            IList<DepartmentListDto> result = await Mediator.Send(new GetListDepartmentQuery());
            return Created("", result);
        }
    }
}