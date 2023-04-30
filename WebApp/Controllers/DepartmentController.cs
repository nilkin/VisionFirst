using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Feature.Departments.Queries;
using Application.Tools;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace WebApp.Controllers
{
    public class DepartmentController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

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

        public async Task<IActionResult> Details(int id)
        {
            DepartmentDetailDto result = await Mediator.Send(new GetDepartmentQuery { Id = id });
            return View(result);
        }

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

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            IList<DepartmentListDto> result = await Mediator.Send(new GetListDepartmentQuery());
            var pageModel = new Pagination<DepartmentListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteDepartmentComand { Id = id });
            return Ok(result);
        }
    }
}
