namespace TestApp.Application.Features.Tests.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Tests.DTOs;

public record GetTestsByCategoryIdQuery(long CategoryId) : IRequest<List<TestDto>>;

public class GetTestsByCategoryIdQueryHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetTestsByCategoryIdQuery, List<TestDto>>
{
    public async Task<List<TestDto>> Handle(
        GetTestsByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        var list = await db.Tests
                           .AsNoTracking()
                           .Where(t => t.CategoryId == request.CategoryId)
                           .ToListAsync(cancellationToken);

        return mp.Map<List<TestDto>>(list);
    }
}