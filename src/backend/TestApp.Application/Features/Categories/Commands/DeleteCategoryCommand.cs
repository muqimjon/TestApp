namespace TestApp.Application.Features.Categories.Commands;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;

public record DeleteCategoryCommand(int Id) : IRequest<int>;

public class DeleteCategoryCommandHandler(IAppDbContext db)
        : IRequestHandler<DeleteCategoryCommand, int>
{
    public async Task<int> Handle(
        DeleteCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await db.Categories
                              .SingleOrDefaultAsync(
                                  c => c.Id == request.Id,
                                  cancellationToken)
        ?? throw new NotFoundException($"Category with Id={request.Id} not found.");

        db.Categories.Remove(entity);

        return await db.SaveAsync(cancellationToken);
    }
}
