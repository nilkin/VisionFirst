using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Feature.Departments.Queries;
using Application.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DepartmentController : BaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddDto model)
        {
            if (ModelState.IsValid)
            {
                CreateDepartmentCommand createDepartmentCommand = new()
                {
                    DepartmentAddDto = model
                };
                int result = await Mediator.Send(createDepartmentCommand);
                return RedirectToAction(nameof(Details), new { id = result });
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            DepartmentDetailDto result = await Mediator.Send(new GetDepartmentQuery { Id = id });
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Details(DepartmentDetailDto model)
        {
            UpdateDepartmentCommand updateDepartmentCommand = new()
            {
                DepartmentDetailDto = model
            };
            DepartmentDetailDto result = await Mediator.Send(updateDepartmentCommand);
            return View(nameof(Details));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            IList<DepartmentListDto> result = await Mediator.Send(new GetListDepartmentQuery());
            var pageModel = new Pagination<DepartmentListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteDepartmentComand { Id = id });
            return Ok(result);
        }
    }
}
