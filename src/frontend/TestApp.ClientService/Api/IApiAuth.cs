namespace TestApp.ClientService.Api;

using Refit;
using TestApp.ClientService.Models;
using TestApp.ClientService.Models.Auth;

public interface IApiAuth
{
    [Post("/Auth/login")]
    Task<Response<LoginResponse>> Login([Body] LoginRequest request);

    [Post("/Auth/register")]
    Task<Response<LoginResponse>> Register([Body] RegisterRequest request);
}
