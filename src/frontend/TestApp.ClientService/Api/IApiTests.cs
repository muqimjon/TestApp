namespace TestApp.ClientService.Api;

using Refit;
using TestApp.ClientService.Models;

public interface IApiTests
{
    [Get("/tests")]
    Task<Response<List<TestDto>>> GetAllTests();

    [Get("/tests/by-category/{categoryId}")]
    Task<Response<List<TestDto>>> GetTestsByCategoryId(long categoryId);
}
