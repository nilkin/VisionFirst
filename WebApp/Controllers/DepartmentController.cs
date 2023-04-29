using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Feature.Departments.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
            CreateDepartmentCommand createDepartmentCommand = new ()
            { 
                DepartmentAddDto = model 
            };
            var result = await Mediator.Send(createDepartmentCommand);
            return RedirectToAction(nameof(Details), new { id = result});
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await Mediator.Send(new GetDepartmentQuery { Id = id });

            return View(product);
        }
    }
}
