namespace TestApp.ClientService.Models;

public class AnswerOptionDto
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}  