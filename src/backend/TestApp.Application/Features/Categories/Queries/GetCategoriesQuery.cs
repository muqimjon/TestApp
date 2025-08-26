namespace TestApp.Application.Features.Categories.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Categories.DTOs;

public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;

public class GetCategoriesQueryHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var list = await db.Categories
                            .AsNoTracking()
                            .ToListAsync(cancellationToken);

        return mp.Map<List<CategoryDto>>(list);
    }
}
