using Application.Feature.Employees.Queries;
using Application.Feature.LeaveApplications.Commands;
using Application.Feature.LeaveApplications.Dtos;
using Application.Feature.LeaveApplications.Queries;
using Application.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LeaveApplicationController : BaseController
    {
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListLeaveApplicationByEmployeeQuery() {SignInId=getUserIdFromRequest() });
            var pageModel = new Pagination<LeaveApplicationListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            LeaveApplicationAddDto model = new();
            return View(model);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Add(LeaveApplicationAddDto model)
        {
            if (ModelState.IsValid)
            {
                model.SignInId = getUserIdFromRequest();
                CreateLeaveApplicationCommand createLeaveApplicationCommand = new()
                {
                    LeaveApplicationAddDto = model
                };
                int result = await Mediator.Send(createLeaveApplicationCommand);
                return RedirectToAction(nameof(Details), new { id = result });
            }
            return View(model);
        }
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Details(int id)
        {
            LeaveApplicationDetailDto result = await Mediator.Send(new GetLeaveApplicationQuery { Id = id });
            return View(result);
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> Details(LeaveApplicationDetailDto model)
        {
            UpdateLeaveApplicationCommand updateLeaveApplicationCommand = new()
            {
                LeaveApplicationDetailDto = model
            };
            LeaveApplicationDetailDto result = await Mediator.Send(updateLeaveApplicationCommand);
            return View(nameof(Details), result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListLeaveApplicationQuery());
            var pageModel = new Pagination<LeaveApplicationListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteLeaveApplicationCommand { Id = id });
            return Ok(result);
        }
    }
}
