namespace TestApp.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Features.Tests.Commands;
using TestApp.Application.Features.Tests.Queries;
using TestApp.Application.Features.TestSessions.Commands;
using TestApp.WebApi.Models;

public class TestsController : BaseController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateTest(CreateTestCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });

    [HttpPost("start")]
    public async Task<IActionResult> StartTest(StartTestSessionCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitTest(SubmitTestSessionCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });

    [HttpGet]
    public async Task<IActionResult> GetTests()
        => Ok(new Response { Data = await Mediator.Send(new GetTestsQuery()) });

    [HttpGet("by-category/{categoryId:long}")]
    public async Task<IActionResult> GetTestsByCategoryId(long categoryId)
        => Ok(new Response { Data = await Mediator.Send(new GetTestsByCategoryIdQuery(categoryId)) });
}