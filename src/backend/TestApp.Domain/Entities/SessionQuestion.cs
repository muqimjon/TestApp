namespace TestApp.Domain.Entities;

public class SessionQuestion : Auditable
{
    public long TestSessionId { get; set; }
    public long QuestionId { get; set; }
    public long SelectedOptionId { get; set; }
    public bool IsCorrect { get; set; }
}