namespace TestApp.Application.Features.TestSessions.DTOs;

using TestApp.Domain.Entities;

public record TestSessionDto(
    long UserId,
    long TestId,
    DateTime StartedAt,
    DateTime? CompletedAt,
    ICollection<SessionQuestion> Questions);