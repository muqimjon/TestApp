namespace TestApp.Application.Features.Tests.Commands;

using AutoMapper;
using MediatR;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Tests.DTOs;
using TestApp.Domain.Entities;

public record CreateTestCommand(string Title, int CategoryId) : IRequest<TestDto>;

public class CreateTestCommandHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<CreateTestCommand, TestDto>
{
    public async Task<TestDto> Handle(
        CreateTestCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Test
        {
            Title = request.Title,
            CategoryId = request.CategoryId
        };

        db.Tests.Add(entity);
        await db.SaveAsync(cancellationToken);

        return mp.Map<TestDto>(entity);
    }
}

