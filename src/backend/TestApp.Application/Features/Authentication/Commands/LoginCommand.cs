namespace TestApp.Application.Features.Authentication.Commands;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Authentication.DTOs;

public record LoginCommand(string Username, string Password) : IRequest<AuthResultDto>;


public class LoginCommandHandler(
    IAppDbContext db,
    IJwtTokenGenerator jwt,
    IPasswordManager ps,
    IMapper mp)
    : IRequestHandler<LoginCommand, AuthResultDto>
{
    public async Task<AuthResultDto> Handle(LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await db.Users
                        .SingleOrDefaultAsync(u
                            => u.Username == request.Username, cancellationToken);

        if (user is null || !ps.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedException("Invalid username or password");

        var userDto = mp.Map<UserDto>(user);
        var token = jwt.GenerateToken(user);

        return new AuthResultDto(token, userDto); ;
    }
}
