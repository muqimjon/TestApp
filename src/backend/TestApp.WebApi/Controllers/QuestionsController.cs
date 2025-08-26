namespace TestApp.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Features.Questions.Commands;
using TestApp.Application.Features.Questions.Queries;
using TestApp.WebApi.Models;

public class QuestionsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> CreateQuestion(AddQuestionCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });

    [HttpGet("by-test/{testId:long}")]
    public async Task<IActionResult> GetQuestionsByTestId(long testId)
        => Ok(new Response { Data = await Mediator.Send(new GetQuestionsByTestIdQuery(testId)) });
}