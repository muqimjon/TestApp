namespace TestApp.Application.Features.TestSessions.Commands;

using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.TestSessions.DTOs;

public record SubmitTestSessionCommand(
    long SessionId,
    List<AnswerSubmissionDto> Answers
) : IRequest<SessionResultDto>;

public class SubmitTestSessionCommandHandler(
    IAppDbContext db
    ) : IRequestHandler<SubmitTestSessionCommand, SessionResultDto>
{
    public async Task<SessionResultDto> Handle(
        SubmitTestSessionCommand request,
        CancellationToken cancellationToken)
    {
        var session = await db.TestSessions
            .Include(ts => ts.Questions)
                .ThenInclude(sq => sq.Question)
                    .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(ts =>
                ts.Id == request.SessionId &&
                ts.CompletedAt == null,
                cancellationToken)
            ?? throw new KeyNotFoundException($"Session {request.SessionId} not found or already completed.");

        foreach (var submission in request.Answers)
        {
            var sq = session.Questions
                .FirstOrDefault(q => q.QuestionId == submission.QuestionId);
            if (sq == null)
                continue;

            sq.SelectedOptionId = submission.SelectedOptionId;
            var opt = sq.Question.Options
                .FirstOrDefault(o => o.Id == submission.SelectedOptionId);

            sq.IsCorrect = opt?.IsCorrect ?? false;
        }

        var total = session.Questions.Count;
        var correct = session.Questions.Count(q => q.IsCorrect);
        var wrong = total - correct;
        var percent = total > 0
            ? (double)correct * 100 / total
            : 0;

        session.CompletedAt = DateTime.UtcNow;
        await db.SaveAsync(cancellationToken);

        var result = new SessionResultDto(
            SessionId: session.Id,
            TotalQuestions: total,
            CorrectAnswers: correct,
            WrongAnswers: wrong,
            Percentage: percent);

        return result;
    }
}