using Application.Feature.Accounts.Commands;
using Application.Feature.Accounts.Dtos;
using Application.Feature.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {

        [HttpPost("register")]
        public async Task<IActionResult> Add(AccountAddDto model)
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
