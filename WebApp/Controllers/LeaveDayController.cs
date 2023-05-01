using Application.Feature.Positions.Queries;
using Application.Feature.LeaveDays.Commands;
using Application.Feature.LeaveDays.Dtos;
using Application.Feature.LeaveDays.Queries;
using Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LeaveDayController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            LeaveDayAddDto model = new();
            model.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(LeaveDayAddDto model)
        {
            model.Positions = await Mediator.Send(new GetListPositionQuery());
            if (ModelState.IsValid)
            {
                CreateLeaveDayCommand createLeaveDayCommand = new()
                {
                    LeaveDayAddDto = model
                };
                int result = await Mediator.Send(createLeaveDayCommand);
                return RedirectToAction(nameof(Details), new { id = result });
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            LeaveDayDetailDto result = await Mediator.Send(new GetLeaveDayQuery { Id = id });
            result.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Details(LeaveDayDetailDto model)
        {
            UpdateLeaveDayCommand updateLeaveDayCommand = new()
            {
                LeaveDayDetailDto = model
            };
            LeaveDayDetailDto result = await Mediator.Send(updateLeaveDayCommand);
            result.Positions = await Mediator.Send(new GetListPositionQuery());
            return View(nameof(Details), result);
        }

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListLeaveDayQuery());
            var pageModel = new Pagination<LeaveDayListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteLeaveDayCommand { Id = id });
            return Ok(result);
        }
    }
}
