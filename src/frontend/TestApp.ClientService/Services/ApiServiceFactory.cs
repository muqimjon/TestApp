namespace TestApp.ClientService.Services;

using Refit;
using System;
using System.Net.Http;

public static class ApiServiceFactory
{
    private const string BaseUrl = "https://localhost:7283/api";

    public static T Create<T>(string? token = null) where T : class
    {
        var httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };

        if (!string.IsNullOrEmpty(token))
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return RestService.For<T>(httpClient);
    }
}
