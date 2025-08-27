namespace TestApp.Application;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Application.Commons;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
