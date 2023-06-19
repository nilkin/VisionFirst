using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Feature.Departments.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepartmentController : BaseApiController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DepartmentAddDto model)
        {
            CreateDepartmentCommand createDepartmentCommand = new()
            {
                DepartmentAddDto = model
            };
            int result = await Mediator.Send(createDepartmentCommand);
            return Created("", result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Details([FromRoute] GetDepartmentQuery getDepartmentQuery)
        {
            DepartmentDetailDto result = await Mediator.Send(getDepartmentQuery);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]  DepartmentDetailDto model)
        {
            UpdateDepartmentCommand updateDepartmentCommand = new()
            {
                DepartmentDetailDto = model
            };
            DepartmentDetailDto result = await Mediator.Send(updateDepartmentCommand);
            return Ok(result);
        }
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            IList<DepartmentListDto> result = await Mediator.Send(new GetListDepartmentQuery());
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteDepartmentComand deleteDepartmentComand)
        {
            string result = await Mediator.Send(deleteDepartmentComand);
            return Ok(result);
        }
    }
}