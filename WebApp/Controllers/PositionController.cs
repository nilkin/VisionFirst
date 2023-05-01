using Application.Feature.Departments.Queries;
using Application.Feature.Positions.Commands;
using Application.Feature.Positions.Dtos;
using Application.Feature.Positions.Queries;
using Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PositionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            PositionAddDto model = new();
            model.Departments = await Mediator.Send(new GetListDepartmentQuery());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PositionAddDto model)
        {
            model.Departments = await Mediator.Send(new GetListDepartmentQuery());
            if (ModelState.IsValid)
            {
                CreatePositionCommand createPositionCommand = new()
                {
                    PositionAddDto = model
                };
                int result = await Mediator.Send(createPositionCommand);
                return RedirectToAction(nameof(Details), new { id = result });
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            PositionDetailDto result = await Mediator.Send(new GetPositionQuery { Id = id });
            result.Departments = await Mediator.Send(new GetListDepartmentQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Details(PositionDetailDto model)
        {
            UpdatePositionCommand updatePositionCommand = new()
            {
                PositionDetailDto = model
            };
            PositionDetailDto result = await Mediator.Send(updatePositionCommand);
            result.Departments = await Mediator.Send(new GetListDepartmentQuery());
            return View(nameof(Details), result);
        }

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListPositionQuery());
            var pageModel = new Pagination<PositionListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeletePositionComand { Id = id });
            return Ok(result);
        }
    }
}
