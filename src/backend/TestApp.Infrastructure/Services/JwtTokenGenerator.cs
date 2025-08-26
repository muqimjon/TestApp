namespace TestApp.Infrastructure.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestApp.Application.Commons.Interfaces;
using TestApp.Domain.Entities;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings settings;
    private readonly byte[] key;

    public JwtTokenGenerator(IOptions<JwtSettings> options)
    {
        settings = options?.Value
            ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(settings.Secret))
            throw new InvalidOperationException("JWT Secret is not configured.");

        key = Encoding.UTF8.GetBytes(settings.Secret);
    }

    public string GenerateToken(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Username", user.Username),
        };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: settings.Issuer,
            audience: settings.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(settings.ExpiryMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
