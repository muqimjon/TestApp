namespace TestApp.Application.Features.Categories.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Categories.DTOs;

public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;

public class GetCategoryByIdQueryHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await db.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Id,
                                  cancellationToken)
            ?? throw new NotFoundException($"Category with Id={request.Id} not found.");

        return mp.Map<CategoryDto>(entity);
    }
}
