namespace TestApp.ClientService.Services;

using System.Threading.Tasks;
using TestApp.ClientService.Api;
using TestApp.ClientService.Models.Auth;

public class AuthService
{
    private readonly IApiAuth api;

    public AuthService()
    {
        api = ApiServiceFactory.Create<IApiAuth>();
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await api.Login(new LoginRequest
        {
            Username = username,
            Password = password
        });

        if (response.StatusCode != 200)
        {
            return true;
        }
        ;

        var loginResponse = response.Data;
        var user = loginResponse.User;

        if (!string.IsNullOrEmpty(loginResponse.Token))
        {
            AuthStore.Instance.SetAuth(loginResponse.Token, user.FullName, user.Id);
            return true;
        }

        return false;
    }

    public async Task<bool> Register(string username, string password, string fullname)
    {
        var response = await api.Register(new RegisterRequest
        {
            Username = username,
            Password = password,
            FullName = fullname
        });

        if (response.StatusCode != 200)
        {
            return true;
        }
        ;

        var loginResponse = response.Data;
        var user = loginResponse.User;

        if (!string.IsNullOrEmpty(loginResponse.Token))
        {
            AuthStore.Instance.SetAuth(loginResponse.Token, user.FullName, user.Id);
            return true;
        }

        return false;
    }

    public void Logout()
    {
        AuthStore.Instance.Logout();
    }
}
