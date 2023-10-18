using Application.Feature.Employees.Commands;
using Application.Feature.Employees.Dtos;
using Application.Feature.Employees.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] EmployeeAddDto model)
        {
            CreateEmployeeCommand createEmployeeCommand = new()
            {
                EmployeeAddDto = model
            };
            int result = await Mediator.Send(createEmployeeCommand);
            return Created("", result);
        }
        [Authorize]   
        [HttpGet("{Id}")]
        public async Task<IActionResult> Details([FromRoute] GetEmployeeQuery getEmployeeQuery)
        {
            EmployeeDetailDto result = await Mediator.Send(getEmployeeQuery);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]  EmployeeDetailDto model)
        {
            UpdateEmployeeCommand updateEmployeeCommand = new()
            {
                EmployeeDetailDto = model
            };
            EmployeeDetailDto result = await Mediator.Send(updateEmployeeCommand);
            return Ok(result);
        }
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            IList<EmployeeListDto> result = await Mediator.Send(new GetListEmployeeQuery());
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteEmployeeCommand deleteEmployeeCommand)
        {
            string result = await Mediator.Send(deleteEmployeeCommand);
            return Ok(result);
        }
    }
}