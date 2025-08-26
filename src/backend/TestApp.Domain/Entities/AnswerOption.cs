namespace TestApp.Domain.Entities;

public class AnswerOption : Auditable
{
    public long QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}