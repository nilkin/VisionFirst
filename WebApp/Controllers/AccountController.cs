using Application.Feature.Accounts.Commands;
using Application.Feature.Accounts.Dtos;
using Application.Feature.Accounts.Queries;
using Application.Feature.Employees.Queries;
using Application.Tools;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginDto account)
        {
            LoginAccountCommand loginAccountCommand = new()
            {
                AccountLoginDto = account
            };
            var result = await Mediator.Send(loginAccountCommand);

            if (result.Id > 0)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticate = false;
                if (result.Role == Role.Admin)
                {
                    identity = new ClaimsIdentity(new[]
                {
                         new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                         new Claim(ClaimTypes.Email, result.Email),
                         new Claim(ClaimTypes.Role ,Role.Admin.ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                else if (result.Role == Role.User)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                         new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                         new Claim(ClaimTypes.Email, result.Email),
                         new Claim(ClaimTypes.Role ,Role.User.ToString())
                     }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;

                }
                if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    if (result.Role == Role.Admin)
                    {
                       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("List", "LeaveApplication");
                    }
                   await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "LeaveApplication");
                }
            }
            ViewBag.Error = "Email ve ya Şifrə yalnışdır";
            return View(new AccountLoginDto()
            {
                Email = result.Email,
                Password = result.NewPassword
            });
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AccountAddDto model = new()
            {
                Employees = await Mediator.Send(new GetListEmployeeQuery())
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AccountAddDto model)
        {
            model.Employees = await Mediator.Send(new GetListEmployeeQuery());
            if (ModelState.IsValid)
            {
                CreateAccountCommand createAccountCommand = new()
                {
                    AccountAddDto = model
                };
                var result = await Mediator.Send(createAccountCommand);
                return RedirectToAction(nameof(Details), new { id = result.Id });
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            AccountDetailDto result = await Mediator.Send(new GetAccountQuery { Id = id });
            result.Employees = await Mediator.Send(new GetListEmployeeQuery());
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Details(AccountDetailDto model)
        {
            UpdateAccountCommand updateAccountCommand = new()
            {
                AccountDetailDto = model
            };
            AccountDetailDto result = await Mediator.Send(updateAccountCommand);
            result.Employees = await Mediator.Send(new GetListEmployeeQuery());
            return View(nameof(Details), result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Mediator.Send(new GetListAccountQuery());
            var pageModel = new Pagination<AccountListDto>(result, pageIndex, pageSize);
            return View(pageModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await Mediator.Send(new DeleteAccountCommand { Id = id });
            return Ok(result);
        }
    }
}
