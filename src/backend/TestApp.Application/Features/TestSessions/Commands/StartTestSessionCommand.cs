namespace TestApp.Application.Features.TestSessions.Commands;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Application.Features.TestSessions.DTOs;
using TestApp.Domain.Entities;

public record StartTestSessionCommand(long UserId, long TestId) : IRequest<TestSessionDto>;

public class StartTestSessionCommandHandler(
    IAppDbContext db,
    IMapper mapper)
    : IRequestHandler<StartTestSessionCommand, TestSessionDto>
{
    public async Task<TestSessionDto> Handle(StartTestSessionCommand cmd, CancellationToken ct)
    {
        var wrongIds = await db.TestSessions
            .Where(s => s.UserId == cmd.UserId && s.TestId == cmd.TestId)
            .SelectMany(s => s.Questions)
            .Where(q => !q.IsCorrect)
            .Select(q => q.QuestionId)
            .Distinct()
            .Take(5)
            .ToListAsync(ct);

        var seenIds = await db.TestSessions
            .Where(s => s.UserId == cmd.UserId && s.TestId == cmd.TestId)
            .SelectMany(s => s.Questions.Select(q => q.QuestionId))
            .Distinct()
            .ToListAsync(ct);

        var newIds = await db.Questions
            .Where(q => q.TestId == cmd.TestId && !seenIds.Contains(q.Id))
            .OrderBy(_ => Guid.NewGuid())
            .Take(20 - wrongIds.Count)
            .Select(q => q.Id)
            .ToListAsync(ct);

        var allIds = wrongIds
            .Concat(newIds)
            .OrderBy(_ => Guid.NewGuid())
            .ToList();

        var session = new TestSession
        {
            UserId = cmd.UserId,
            TestId = cmd.TestId,
            StartedAt = DateTime.UtcNow,
            Questions = [.. allIds.Select(id => new SessionQuestion
            {
                QuestionId = id,
                SelectedOptionId = 0,
                IsCorrect = false
            })]
        };

        db.TestSessions.Add(session);
        await db.SaveAsync(ct);

        var loaded = await db.TestSessions
            .Where(s => s.Id == session.Id)
            .Include(s => s.Questions)
                .ThenInclude(q => q.Question)
                    .ThenInclude(x => x.Options)
            .AsNoTracking()
            .FirstAsync(ct);

        return mapper.Map<TestSessionDto>(loaded);
    }
}
