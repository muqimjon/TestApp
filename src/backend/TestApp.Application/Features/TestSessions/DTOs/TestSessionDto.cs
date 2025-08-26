namespace TestApp.Application.Features.TestSessions.DTOs;

using TestApp.Domain.Entities;

public record TestSessionDto
{
    public long UserId { get; set; } = default!;
    public long TestId { get; set; } = default!;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<SessionQuestion> Questions { get; set; } = [];
}