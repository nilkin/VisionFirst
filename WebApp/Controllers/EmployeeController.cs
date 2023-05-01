using Application.Feature.Positions.Queries;
using Application.Feature.Employees.Commands;
using Application.Feature.Employees.Dtos;
using Application.Feature.Employees.Queries;
using Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EmployeeAddDto model = new();
            model.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto model)
        {
            model.Positions = await Mediator.Send(new GetListPositionQuery());
            if (ModelState.IsValid)
            {
                CreateEmployeeCommand createEmployeeCommand = new()
                {
                    EmployeeAddDto = model
                };
                int result = await Mediator.Send(createEmployeeCommand);
                return RedirectToAction(nameof(Details), new { id = result });
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            EmployeeDetailDto result = await Mediator.Send(new GetEmployeeQuery { Id = id });
            result.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Details(EmployeeDetailDto model)
        {
            UpdateEmployeeCommand updateEmployeeCommand = new()
            {
                EmployeeDetailDto = model
            };
            EmployeeDetailDto result = await Mediator.Send(updateEmployeeCommand);
            result.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(nameof(Details), result);
        }

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListEmployeeQuery());
            var pageModel = new Pagination<EmployeeListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(result);
        }
    }
}
