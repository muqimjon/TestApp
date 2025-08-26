namespace TestApp.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestApp.Application.Features.Authentication.Commands;
using TestApp.WebApi.Models;

public class AuthController : BaseController
{
    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginCommand loginCommand)
        => Ok(new Response { Data = await Mediator.Send(loginCommand) });

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand model)
        => Ok(new Response { Data = await Mediator.Send(model) });
}
