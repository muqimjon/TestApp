namespace TestApp.Application.Features.TestSessions.DTOs;

public record SessionResultDto(
    long SessionId,
    int TotalQuestions,
    int CorrectAnswers,
    int WrongAnswers,
    double Percentage);