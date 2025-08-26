namespace TestApp.Application.Features.Categories.Commands;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Categories.DTOs;
using TestApp.Domain.Entities;

public record CreateCategoryCommand(string Name) : IRequest<CategoryDto>;

public class CreateCategoryCommandHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        if (await db.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken))
            throw new ConflictException($"Category with Name='{request.Name}' already exists.");

        var entity = new Category { Name = request.Name };

        db.Categories.Add(entity);
        await db.SaveAsync(cancellationToken);

        return mp.Map<CategoryDto>(entity);
    }
}
