namespace TestApp.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Application.Commons.Interfaces;
using TestApp.Infrastructure.Persistence;
using TestApp.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration conf)
    {
        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseNpgsql(conf.GetConnectionString("DefaultConnection")));

        services.Configure<JwtSettings>(opts => conf.GetSection("JwtSettings"))
            .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IPasswordManager, PasswordManager>();

        return services;
    }
}
