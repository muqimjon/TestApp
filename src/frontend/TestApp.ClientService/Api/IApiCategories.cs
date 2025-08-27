namespace TestApp.ClientService.Api;

using Refit;
using TestApp.ClientService.Models;

public interface IApiCategories
{
    [Get("/categories")]
    Task<Response<List<CategoryDto>>> GetAllCategoriesAsync();

    [Post("/categories/delete/{id}")]
    Task DeleteCategory(long id);

    [Post("/categories/create")]
    Task CreateCategory(string name);
}