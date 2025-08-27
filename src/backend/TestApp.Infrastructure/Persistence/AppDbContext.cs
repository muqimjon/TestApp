namespace TestApp.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using TestApp.Application.Commons.Interfaces;
using TestApp.Domain.Entities;

public class AppDbContext(DbContextOptions options) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    public DbSet<TestSession> TestSessions { get; set; }
    public DbSet<SessionQuestion> SessionQuestions { get; set; }
    public DbSet<Category> Categories { get; set; }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        => await SaveChangesAsync(cancellationToken);
}
