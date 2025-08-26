namespace TestApp.Application.Features.Questions.Queries;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.Questions.DTOs;

public record GetQuestionsByTestId(int TestId) : IRequest<List<QuestionDto>>;

public class GetQuestionsByTestIdHandler(
    IAppDbContext db,
    IMapper mp)
    : IRequestHandler<GetQuestionsByTestId, List<QuestionDto>>
{
    public async Task<List<QuestionDto>> Handle(
        GetQuestionsByTestId request,
        CancellationToken cancellationToken)
    {
        var questions = await db.Questions
                                .Include(q => q.Options)
                                .Where(q => q.TestId == request.TestId)
                                .AsNoTracking()
                                .ToListAsync(cancellationToken);

        return mp.Map<List<QuestionDto>>(questions);
    }
}
