namespace TestApp.Application.Commons.Interfaces;

using TestApp.Domain.Entities;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}