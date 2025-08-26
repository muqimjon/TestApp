namespace TestApp.Application.Commons.Interfaces;

using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Entities;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<Test> Tests { get; }
    DbSet<Question> Questions { get; }
    DbSet<AnswerOption> AnswerOptions { get; }
    DbSet<TestSession> TestSessions { get; }
    DbSet<SessionQuestion> SessionQuestions { get; }
    DbSet<Category> Categories { get; }
    Task<int> SaveAsync(CancellationToken cancellationToken);
}
