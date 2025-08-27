namespace TestApp.Application.Features.Questions.Commands;

using AutoMapper;
using MediatR;
using TestApp.Application.Commons.Exceptions;
using TestApp.Application.Commons.Interfaces;

public record UpdateQuestionCommand(long Id, long TestId, string Text) : IRequest<long>;

public class UpdateQuestionCommandHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<UpdateQuestionCommand, long>
{
    public async Task<long> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var entity = db.Questions.FirstOrDefault(q => q.Id == request.Id) 
            ?? throw new NotFoundException($"Question with Id={request.Id} not found.");

        mp.Map(request, entity);
        db.Questions.Update(entity);
        await db.SaveAsync(cancellationToken);
        return entity.Id;
    }
}