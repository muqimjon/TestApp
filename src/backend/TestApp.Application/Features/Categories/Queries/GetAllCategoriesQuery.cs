namespace TestApp.Application.Features.Categories.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Categories.DTOs;

public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;

public class GetAllCategoriesQueryHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var list = await db.Categories
                            .Include(c => c.Tests)
                            .AsNoTracking()
                            .ToListAsync(cancellationToken);

        return mp.Map<List<CategoryDto>>(list);
    }
}
