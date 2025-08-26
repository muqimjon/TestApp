namespace TestApp.Application.Features.Authentication.Commands;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Authentication.DTOs;
using TestApp.Domain.Entities;

public record RegisterCommand(
    string FullName,
    string Username,
    string Password)
    : IRequest<AuthResultDto>;

public class RegisterCommandHandler(
    IAppDbContext db,
    IJwtTokenGenerator jwt,
    IPasswordManager ps,
    IMapper mp)
    : IRequestHandler<RegisterCommand, AuthResultDto>
{
    public async Task<AuthResultDto> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        if (await db.Users.AnyAsync(u => u.Username == request.Username, cancellationToken))
            throw new ConflictException("Username already taken");

        var hash = ps.Hash(request.Password);
        var user = new User
        {
            FullName = request.FullName,
            Username = request.Username,
            PasswordHash = hash
        };

        db.Users.Add(user);
        await db.SaveAsync(cancellationToken);

        var userDto = mp.Map<UserDto>(user);
        var token = jwt.GenerateToken(user);

        return new AuthResultDto(token, userDto);
    }
}

