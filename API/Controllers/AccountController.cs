using Application.Feature.Accounts.Commands;
using Application.Feature.Accounts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginDto account)
        {
            LoginAccountApiCommand loginAccountCommand = new()
            {
                AccountLoginDto = account
            };
            var result = await Mediator.Send(loginAccountCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountAddDto model)
        {
            CreateAccountCommand createAccountCommand = new()
            {
                AccountAddDto = model
            };
            AccountRegisterDto result = await Mediator.Send(createAccountCommand);
            return Ok(result);
        }
    }
}
