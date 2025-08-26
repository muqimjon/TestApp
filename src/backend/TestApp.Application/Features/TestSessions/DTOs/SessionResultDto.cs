namespace TestApp.Application.Features.TestSessions.DTOs;

public record SessionResultDto
{
    public long SessionId { get; set; } = default!;
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public double Percentage { get; set; }
}