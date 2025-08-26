namespace TestApp.Application.Features.Tests.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Tests.DTOs;

public record GetTestsQuery() : IRequest<List<TestDto>>;

public class GetTestsQueryHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetTestsQuery, List<TestDto>>
{
    public async Task<List<TestDto>> Handle(
        GetTestsQuery request,
        CancellationToken cancellationToken)
    {
        var list = await db.Tests
                           .AsNoTracking()
                           .ToListAsync(cancellationToken);

        return mp.Map<List<TestDto>>(list);
    }
}
