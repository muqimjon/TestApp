namespace TestApp.Application.Features.Categories.Commands;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Domain.Entities;

public record FindOrCreateCategoryCommand(string Name) : IRequest<long>;

public class FindOrCreateCategoryCommandHandler(
    IAppDbContext db) 
    : IRequestHandler<FindOrCreateCategoryCommand, long>
{
    public async Task<long> Handle(FindOrCreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await db.Categories.FirstOrDefaultAsync(c => c.Name == request.Name, cancellationToken);
        if(category is not null)
            return category.Id; 

        await db.Categories.AddAsync(category = new Category { Name = request.Name }, cancellationToken);
        await db.SaveAsync(cancellationToken);
        return category.Id;
    }
}