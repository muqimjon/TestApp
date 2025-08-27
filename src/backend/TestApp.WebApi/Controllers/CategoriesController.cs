namespace TestApp.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Features.Categories.Commands;
using TestApp.Application.Features.Categories.Queries;
using TestApp.WebApi.Models;

public class CategoriesController : BaseController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteCategory(long id)
        => Ok(new Response { Data = await Mediator.Send(new DeleteCategoryCommand(id)) });

    [HttpGet("by-id/{id:long}")]
    public async Task<IActionResult> GetCategoryById(long id)
        => Ok(new Response { Data = await Mediator.Send(new GetCategoryByIdQuery(id)) });

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
        => Ok(new Response { Data = await Mediator.Send(new GetAllCategoriesQuery()) });

    [HttpPost("find-or-create")]
    public async Task<IActionResult> FindOrCreateCategory(FindOrCreateCategoryCommand command)
        => Ok(new Response { Data = await Mediator.Send(command) });
}
